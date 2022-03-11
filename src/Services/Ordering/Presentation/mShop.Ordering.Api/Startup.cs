using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using mShop.Core.Infrastructure;
using mShop.Ordering.Api.Infrastructure.StartupExtensions;

namespace mShop.Ordering.Api
{
    public partial class Startup
    {
        /// <summary>
        /// Defines the _configuration.
        /// </summary>
        private readonly IConfiguration _configuration;

        private readonly IHostingEnvironment _webHostEnvironment;

        /// <summary>
        /// Defines the _engine.
        /// </summary>
        private IEngine _engine;

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration<see cref="IConfiguration"/>.</param>
        public Startup(IConfiguration configuration, IHostingEnvironment webHostEnvironment)
        {
            _configuration = configuration;

            _webHostEnvironment = webHostEnvironment;
        }

        /// <summary>
        /// Add services to the application and configure service provider.
        /// </summary>
        /// <param name="services">Collection of service descriptors.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            _engine = services.ConfigureApplicationServices(_configuration, _webHostEnvironment);
        }

        /// <summary>
        /// The ConfigureContainer.
        /// </summary>
        /// <param name="builder">The builder<see cref="ContainerBuilder"/>.</param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            _engine.RegisterDependencies(builder);
        }

        /// <summary>
        /// Configure the application HTTP request pipeline.
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline.</param>
        public void Configure(IApplicationBuilder application)
        {
            application.ConfigureRequestPipeline();
        }
    }
}
