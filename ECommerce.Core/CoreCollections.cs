using ECommerce.Core.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ECommerce.Core
{
    public static class CoreCollections
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            // mediator
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            // fluent validation
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            // mapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}