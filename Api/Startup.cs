using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyMoon.Application;
using MyMoon.Infrastructure;
using System;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IConfiguration _configuration;
        private ILoggerFactory _loggerFactory;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication();
            services.AddInfrastructure(_configuration);

            services.AddHttpContextAccessor();
            services.AddHealthChecks();
            services.AddControllers();
            //.AddFluentValidation(options => options.RegisterValidatorsFromAssembly(typeof(MyMoon.Application.DependencyInjection).Assembly));

            //services.AddOpenApiDocument();
            services.AddSwaggerDocument((opt) =>
            {
                opt.Version = "v1";
                opt.Title = "My Moon";
            });

            services.ConfigureApplicationCookie(config =>
            {
                config.LoginPath = "/Users/Login";
                config.SlidingExpiration = true;
                config.ExpireTimeSpan = TimeSpan.FromMinutes(40);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHealthChecks("/health");

            app.UseHttpsRedirection();

            //app.UseSwaggerUi3(settings =>
            //{
            //    settings.Path = "/api";
            //    settings.DocumentPath = "/specification.json";
            //});

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
