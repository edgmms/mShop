﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using mShop.Catalog.Core.Infrastructure;
using mShop.Catalog.Data.Infrastructure;

namespace mShop.Catalog.Data
{
    /// <summary>
    /// Defines the <see cref="MongoDbStartup" />.
    /// </summary>
    public class MongoDbStartup : IMShopStartup
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
