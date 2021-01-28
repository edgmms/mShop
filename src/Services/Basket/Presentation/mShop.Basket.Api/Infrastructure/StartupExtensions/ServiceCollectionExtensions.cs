using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using mShop.Basket.Data;
using mShop.Core;
using mShop.Core.Infrastructure;
using mShop.EventBus;
using Newtonsoft.Json.Serialization;
using RabbitMQ.Client;
using System;
using System.Net;

namespace mShop.Basket.Api.Infrastructure.StartupExtensions
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
            services.ConfigureStartupConfig<BasketDbSettings>(configuration.GetSection("BasketDbSettings"));

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

        /// <summary>
        /// Add and configure MVC for the application.
        /// </summary>
        /// <param name="services">Collection of service descriptors.</param>
        /// <returns>A builder for configuring MVC services.</returns>
        public static IMvcBuilder AddBasketMvc(this IServiceCollection services)
        {
            //add basic MVC feature
            var mvcBuilder = services.AddControllers();

            //MVC now serializes JSON with camel case names by default, use this code to avoid it
            mvcBuilder.AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            //register controllers as services, it'll allow to override them
            mvcBuilder.AddControllersAsServices();

            return mvcBuilder;
        }

        /// <summary>
        /// The AddSwaggerGen.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        public static void AddBasketSwaggerGen(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "mShop Basket Api", Version = "v1" });

                //if want to use jwt berarer token for api access
                //instal Microsoft.AspNetCore.Authentication.JwtBearer package and  remove comment lines

                //c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                //{
                //    Name = "Authorization",
                //    Type = SecuritySchemeType.ApiKey,
                //    Scheme = "Bearer",
                //    In = ParameterLocation.Header,
                //    BearerFormat = "JWT",
                //    Description = "Please Enter Jwt Auth Encrypted Value",
                //});

                //c.AddSecurityRequirement(new OpenApiSecurityRequirement
                //{
                //    {
                //        new OpenApiSecurityScheme
                //        {
                //            Reference = new OpenApiReference
                //            {
                //                Type = ReferenceType.SecurityScheme,
                //                Id = "Bearer"
                //            }
                //        },
                //        new string[] {}
                //    }
                //});
            });
        }

        /// <summary>
        /// The AddJwtBearerAuthentication.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        public static void AddJwtBearerAuthentication(this IServiceCollection services)
        {
            //var bytes = Encoding.ASCII.GetBytes(JwtBearerSettings.JwtSecretKey);

            //services.AddAuthentication(x =>
            //{
            //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(x =>
            //{
            //    x.RequireHttpsMetadata = false;
            //    x.SaveToken = true;
            //    x.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(bytes),
            //        ValidateIssuer = false,
            //        ValidateAudience = false
            //    };
            //});
        }

        public static void AddBasketEventBus(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IRabbitMQConnection>(sp =>
            {
                var factory = new ConnectionFactory()
                {
                    HostName = configuration["EventBusSettings:Hostname"]
                };

                if (!string.IsNullOrEmpty(configuration["EventBusSettings:Username"]))
                    factory.UserName = configuration["EventBusSettings:Username"];

                if (!string.IsNullOrEmpty(configuration["EventBusSettings:Password"]))
                    factory.Password = configuration["EventBusSettings:Password"];

                return new RabbitMQConnection(factory);
            });
        }
    }
}
