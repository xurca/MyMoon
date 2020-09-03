using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MyMoon.Application.Common.Behaviors;
using MyMoon.Application.Common.Interfaces;
using MyMoon.Domain.Common;
using System.Linq;
using System.Reflection;

namespace MyMoon.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            services.Scan(x =>
            {
                x.FromAssemblies(typeof(DependencyInjection).Assembly)
                 .AddClasses(classes => classes.AssignableTo(typeof(IEventHandler<>)))
                 .AsImplementedInterfaces()
                 .WithTransientLifetime();
            });

            return services;
        }

    }
}
