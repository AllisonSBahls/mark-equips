using MarkEquipsAPI.Repository.Context;
using MarkEquipsAPI.Repository;
using MarkEquipsAPI.Services;
using MarkEquipsAPI.Services.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MarkEquipsAPI.Repository.Generic;
using AutoMapper;
using Microsoft.Net.Http.Headers;
using MarkEquipsAPI.Hypermedia.Filters;
using MarkEquipsAPI.Hypermedia.Enricher;
using Microsoft.OpenApi.Models;
using System;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Identity;
using MarkEquipsAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MarkEquipsAPI.Helpers;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace MarkEquipsAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            IdentityBuilder builder = services.AddIdentityCore<User>(options =>
           {
               options.Password.RequireDigit = false;
               options.Password.RequireNonAlphanumeric = false;
               options.Password.RequireLowercase = false;
               options.Password.RequireUppercase = false;
           });


            builder = new IdentityBuilder(builder.UserType, typeof(Role), builder.Services);
            builder.AddEntityFrameworkStores<MarkEquipsContext>();
            builder.AddRoleValidator<RoleValidator<Role>>();
            builder.AddRoleManager<RoleManager<Role>>();
            builder.AddSignInManager<SignInManager<User>>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                            .GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });

            services.AddMvc(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });


            services.AddCors(options => options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            })
            ); ;
            services.AddControllers();
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


            services.AddDbContext<MarkEquipsContext>(option => option.UseMySql(
                Configuration.GetConnectionString("DefaultConnection"),
                mySqlOptions =>
            {
                mySqlOptions.ServerVersion(new Version(5, 7, 22), ServerType.MySql)
                .EnableRetryOnFailure(
                maxRetryCount: 10,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null);
            }));

            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));
            }).AddXmlSerializerFormatters();

            var filterOptions = new HyperMediaFilterOptions();
            filterOptions.ContentResponseEnricherList.Add(new EquipmentEnricher());
            filterOptions.ContentResponseEnricherList.Add(new ReserverEnricher());
            filterOptions.ContentResponseEnricherList.Add(new ScheduleEnricher());
            filterOptions.ContentResponseEnricherList.Add(new UserEnricher());
            services.AddSingleton(filterOptions);

            services.AddApiVersioning();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Mark Equips - API",
                        Version = "v1",
                        Description = "API RESTFul developer Mark Equips - API",
                        Contact = new OpenApiContact
                        {
                            Name = "Allison Sousa Bahls",
                            Url = new Uri("https://github.com/allisonsbahls")
                        }
                    });
            });

            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<SeedingReservations>();
            services.AddScoped<IEquipmentService, EquipmentServiceImplementation>();
            services.AddScoped<IScheduleService, ScheduleServiceImplementation>();
            services.AddScoped<IReserverService, ReserverServiceImplementation>();
            services.AddScoped<IUserService, UserServiceImplementation>();


            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IReserverRepository), typeof(ReserverRepository));
            services.AddScoped(typeof(IEquipmentRepository), typeof(EquipmentRepository));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<AuthenticatedUser>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env
            // SeedingReservations seedingReservations
            )
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //seedingReservations.SeedRoles();
                //seedingReservations.SeedUsers();
                //seedingReservations.SeedOther();
            }


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mark Equips API - v1");
            });
            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute("DefaultApi", "{controller=values}/{id?}");
            });

        }

    }

}
