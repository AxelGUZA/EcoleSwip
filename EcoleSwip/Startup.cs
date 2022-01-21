using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EcoleSwip.Services;
using EcoleSwip.DAL;
using Microsoft.EntityFrameworkCore;

namespace EcoleSwip
{


    public class Startup
    {
        private string[] _corsOrigins = {
            "http://localhost:4200"
        };

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(setupAction =>
            {
                setupAction.AddDefaultPolicy(builder => builder.WithOrigins(_corsOrigins)
                                                               .AllowAnyMethod()
                                                               .AllowAnyHeader()
                                                               .AllowCredentials());
            });
            services.AddAuthentication(IISDefaults.AuthenticationScheme);

            services.AddDbContext<SchoolContext>();
            services.AddTransient<SchoolService>();

            services.AddControllers();

            services.AddSwaggerGen(c =>
           {
               c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "SwipSchool", Version = "v1" });
           });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SwipSchool v1"));
            }


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
