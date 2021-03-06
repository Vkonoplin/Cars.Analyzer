﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using VK.Cars.Analyzer.Service.WebApi.Business.Repositories;
using VK.Cars.Analyzer.Service.WebApi.Business.Services;
using VK.Cars.Analyzer.Service.WebApi.Db;
using VK.Cars.Analyzer.Service.WebApi.Infrastructure;

namespace VK.Cars.Analyzer.Service.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("Sql");
            services.AddDbContext<DbSqlContext>(options => options.UseSqlServer(connectionString));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Cars Analyzer API Service", Version = "v1" });
            });

            services.AddOptions();

            services.AddTransient<IHealthCheckRepository, HealthCheckRepository>();

            services.AddTransient<HealthCheckService>();

            services.AddMvc(options => { options.Filters.Add<ExceptionFilter>(); }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Manifest API");
            });
            app.UseMvc();
        }
    }
}
