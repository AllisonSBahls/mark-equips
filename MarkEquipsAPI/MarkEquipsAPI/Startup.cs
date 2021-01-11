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
            services.AddControllers();

            var connection = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<MarkEquipsContext>(option => option.UseMySql(connection));

            services.AddApiVersioning();

            services.AddScoped<SeedingReservations>();
            services.AddScoped<IEquipmentService, EquipmentServiceImplementation>();
            services.AddScoped<ICollaboratorService, CollaboratorServiceImplementation>();
            services.AddScoped<IReserverService, ReserverServiceImplementation>();
            services.AddScoped<IScheduleService, ScheduleServiceImplementation>();

            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
       
    }
   
}
