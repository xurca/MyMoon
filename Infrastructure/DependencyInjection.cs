using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyMoon.Application.Common.Interfaces;
using MyMoon.Infrastructure.EventDispatching;
using MyMoon.Infrastructure.Persistence;

namespace MyMoon.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            ILoggerFactory loggerFactory = LoggerFactory.Create(x => { x.AddConsole(); }); //todo: could not handle loggerfactory from configureservices part in startup

            services
                .AddDbContext<MyMoonDbContext>(opt =>
                {
                    opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), options =>
                    {
                        options.MigrationsAssembly(typeof(MyMoonDbContext).Assembly.FullName);
                    });

                    var enableDbLog = bool.Parse(configuration.GetSection("ApplicationSettings").GetSection("LogDb").Value);
                    
                    if (enableDbLog)
                        opt.UseLoggerFactory(loggerFactory);
                });

            services.AddScoped<IDbContext>(provider => provider.GetService<MyMoonDbContext>());

            services.AddScoped<IEventDispatcher>(provider => provider.GetService<EventDispatcher>());

            return services;
        }
    }
}
