using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyMoon.Application.Common.Interfaces;
using MyMoon.Domain.UserManagement;
using MyMoon.Infrastructure.EventDispatching;
using MyMoon.Infrastructure.Identity;
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

            services.AddScoped<IEventDispatcher, EventDispatcher>();

            services.AddIdentity<User, Role>(opt =>
            {
                opt.SignIn.RequireConfirmedEmail = false;
                opt.SignIn.RequireConfirmedPhoneNumber = false;
                opt.SignIn.RequireConfirmedAccount = false;

                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequiredLength = 3;

                opt.User.RequireUniqueEmail = true;
            })
                .AddUserStore<UserStore<User, Role, MyMoonDbContext, int, UserClaim, UserRole, UserLogin, UserToken,
                    RoleClaim>>()
                .AddRoleManager<RoleManager<Role>>()
                .AddRoleStore<RoleStore<Role, MyMoonDbContext, int, UserRole, RoleClaim>>()
                .AddSignInManager<SignInManager<User>>()
                .AddUserManager<UserManager<User>>()
                .AddDefaultTokenProviders()
                .AddUserValidator<UserValidator<User>>();

            services.AddScoped<IUserClaimsPrincipalFactory<User>, CustomClaimsFactory>();

            return services;
        }
    }
}
