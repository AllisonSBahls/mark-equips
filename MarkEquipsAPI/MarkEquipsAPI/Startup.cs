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

            var connection = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<MarkEquipsContext>(option => option.UseMySql(connection));

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


            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IReserverRepository), typeof(ReserverRepository));
            services.AddScoped(typeof(IEquipmentRepository), typeof(EquipmentRepository));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SeedingReservations seedingReservations)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                seedingReservations.Seed();
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


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute("DefaultApi", "{controller=values}/{id?}");
            });
        }

    }

}
