using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using mShop.Core.Infrastructure;

namespace mShop.Catalog.Data.Infrastructure
{
    /// <summary>
    /// Defines the <see cref="CatalogDbStartup" />.
    /// </summary>
    public partial class CatalogDbStartup : IMShopStartup
    {
        /// <summary>
        /// Gets the Order.
        /// </summary>
        public int Order => -11111;

        /// <summary>
        /// The Configure.
        /// </summary>
        /// <param name="application">The application<see cref="IApplicationBuilder"/>.</param>
        public void Configure(IApplicationBuilder application)
        {
            EngineContext.Current.Resolve<IDbInitializer>().Initialize();
        }

        /// <summary>
        /// The ConfigureServices.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        /// <param name="configuration">The configuration<see cref="IConfiguration"/>.</param>
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
        }
    }
}
