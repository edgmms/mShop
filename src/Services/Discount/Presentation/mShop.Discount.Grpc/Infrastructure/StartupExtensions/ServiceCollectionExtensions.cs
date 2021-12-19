using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using mShop.Discount.Data;
using mShop.Core;
using mShop.Core.Infrastructure;
using System;
using System.Net;

namespace mShop.Discount.Grpc.Infrastructure.StartupExtensions
{
    /// <summary>
    /// Represents extensions of IServiceCollection.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add services to the application and configure service provider.
        /// </summary>
        /// <param name="services">Collection of service descriptors.</param>
        /// <param name="configuration">Configuration of the application.</param>
        /// <param name="webHostEnvironment">Hosting environment.</param>
        /// <returns>Configured service provider.</returns>
        public static IEngine ConfigureApplicationServices(this IServiceCollection services,
            IConfiguration configuration, IHostingEnvironment webHostEnvironment)
        {
            //most of API providers require TLS 1.2 nowadays
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            //set catalog db settings
            services.ConfigureStartupConfig<DiscountDbSettings>(configuration.GetSection("DiscountDbSettings"));

            //add accessor to HttpContext
            services.AddHttpContextAccessor();

            //create default file provider
            CommonHelper.DefaultFileProvider = new MShopFileProvider(webHostEnvironment);

            services.AddMvcCore();

            //create engine and configure service provider
            var engine = EngineContext.Create();

            engine.ConfigureServices(services, configuration);

            return engine;
        }

        /// <summary>
        /// Create, bind and register as service the specified configuration parameters.
        /// </summary>
        /// <typeparam name="TConfig">Configuration parameters.</typeparam>
        /// <param name="services">Collection of service descriptors.</param>
        /// <param name="configuration">Set of key/value application configuration properties.</param>
        /// <returns>Instance of configuration parameters.</returns>
        public static TConfig ConfigureStartupConfig<TConfig>(this IServiceCollection services, IConfiguration configuration) where TConfig : class, new()
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            //create instance of config
            var config = new TConfig();

            //bind it to the appropriate section of configuration
            configuration.Bind(config);

            //and register it as a service
            services.AddSingleton(config);

            return config;
        }

        /// <summary>
        /// Register HttpContextAccessor.
        /// </summary>
        /// <param name="services">Collection of service descriptors.</param>
        public static void AddHttpContextAccessor(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
