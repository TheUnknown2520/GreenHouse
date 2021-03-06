using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreenHouse_API.Managers;
using GreenHouse_API.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenHouse_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<GreenHouseDbContext>(opt =>opt.UseSqlServer("Server=tcp:greenhouse-apidbserver.database.windows.net,1433;Initial Catalog=GreenHouse_API_db;Persist Security Info=False;User ID=green2022;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
                
            //services.AddSingleton<GreenHouseManagerDB, GreenHouseManagerDB>();

                services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GreenHouse_API", Version = "v1" });
            });

            // CORS 
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("http://zealand.dk").
                        AllowAnyMethod().
                        AllowAnyHeader()
                );
                options.AddPolicy("AllowAny",
                    builder => builder.AllowAnyOrigin().
                        AllowAnyMethod().
                        AllowAnyHeader()
                );
                options.AddPolicy("AllowOnlyGetPut",
                    builder => builder.AllowAnyOrigin().
                        WithMethods("GET", "PUT").
                        AllowAnyHeader()
                );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GreenHouse_API v1"));
            }

            app.UseRouting();

            app.UseCors("AllowOnlyGetPut");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
