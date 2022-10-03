using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PruebaGranTitan.Application;
using PruebaGranTitan.Data;
using System;
using System.Collections.Generic;
using System.IO;

namespace PruebaGranTitan.WebApi
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

            services.AddControllers();
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<INumberService, NumberService>();
            services.AddScoped<IColorService, ColorService>();
            services.AddScoped<IStateService, StateService>();
            services.AddScoped<IBetService, BetService>();
            services.AddScoped<IRouletteService, RouletteService>();
            services.AddScoped<INumberService, NumberService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PruebaGranTitan.WebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PruebaGranTitan.WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            var installFiles = new List<string>
            {
                Path.Combine(AppContext.BaseDirectory, @"App_Data/Install/SqlServer.StoredProcedures.sql"),
                Path.Combine(AppContext.BaseDirectory, @"App_Data/Install/SqlServer.Data.sql")
            };
        }
    }
}