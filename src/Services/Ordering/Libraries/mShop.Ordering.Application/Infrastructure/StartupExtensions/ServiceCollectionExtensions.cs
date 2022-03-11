using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using mShop.Ordering.Application.Behaviours;
using System.Reflection;

namespace mShop.Ordering.Application.Infrastructure.StartupExtensions
{
    /// <summary>
    /// Defines the <see cref="ServiceCollectionExtensions" />.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// The AddMediatRImplementation.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        public static void AddMediatRImplementation(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }

        /// <summary>
        /// The AddFulentValidation.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        public static void AddFulentValidation(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        }
    }
}
