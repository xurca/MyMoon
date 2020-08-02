using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyMoon.Application.Common.Interfaces;
using MyMoon.Infrastructure.Persistence;

namespace MyMoon.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyMoonDbContext>(x => x.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IDbContext>(provider => provider.GetService<MyMoonDbContext>());

            return services;
        }
    }
}
