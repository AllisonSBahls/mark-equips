using MarkEquipsAPI.Repository.Context;
using MarkEquipsAPI.Repository;
using MarkEquipsAPI.Repository.Implementations;
using MarkEquipsAPI.Services;
using MarkEquipsAPI.Services.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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

            services.AddScoped<IEntitieService, EquipmentServiceImplementation>();
            services.AddScoped<IEntitieRepository, EquipmentRepositoryImplementation>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
