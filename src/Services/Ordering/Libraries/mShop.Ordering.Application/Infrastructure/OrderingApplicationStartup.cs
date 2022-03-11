using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using mShop.Core.Infrastructure;
using mShop.Ordering.Application.Infrastructure.StartupExtensions;

namespace mShop.Ordering.Application.Infrastructure
{
    /// <summary>
    /// Defines the <see cref="OrderingApplicationStartup" />.
    /// </summary>
    public class OrderingApplicationStartup : IMShopStartup
    {
        /// <summary>
        /// The ConfigureServices.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        /// <param name="configuration">The configuration<see cref="IConfiguration"/>.</param>
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            //add mediatr
            services.AddMediatRImplementation();

            //add fluent validation
            services.AddFulentValidation();
        }

        /// <summary>
        /// The Configure.
        /// </summary>
        /// <param name="application">The application<see cref="IApplicationBuilder"/>.</param>
        public void Configure(IApplicationBuilder application)
        {

        }

        /// <summary>
        /// Gets the Order.
        /// </summary>
        public int Order => 101;
    }
}
