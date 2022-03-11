using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using mShop.Core.Infrastructure;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;

namespace mShop.Ordering.Api.Infrastructure.StartupExtensions
{
    /// <summary>
    /// Represents extensions of IApplicationBuilder.
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Configure the application HTTP request pipeline.
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline.</param>
        public static void ConfigureRequestPipeline(this IApplicationBuilder application)
        {
            EngineContext.Current.ConfigureRequestPipeline(application);
        }

        /// <summary>
        /// Add exception handling.
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline.</param>
        public static void UseOrderExceptionHandler(this IApplicationBuilder application)
        {
            var webHostEnvironment = EngineContext.Current.Resolve<IWebHostEnvironment>();
            var useDetailedExceptionPage = webHostEnvironment.IsDevelopment();
            if (useDetailedExceptionPage)
            {
                //get detailed exceptions for developing and testing purposes
                application.UseDeveloperExceptionPage();
            }
            else
            {
                //or use special exception handler
                application.UseExceptionHandler("/Error/Error");
            }

            //log errors
            application.UseExceptionHandler(handler =>
            {
                handler.Run(context =>
                {
                    var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
                    if (exception == null)
                        return Task.CompletedTask;

                    try
                    {
                        //get current customer
                        //var currentCustomer = EngineContext.Current.Resolve<IWorkContext>().CurrentCustomer;

                        //log error
                        //EngineContext.Current.Resolve<ILogger>().Error(exception.Message, exception, currentCustomer);
                    }
                    finally
                    {
                        //rethrow the exception to show the error page
                        ExceptionDispatchInfo.Throw(exception);
                    }

                    return Task.CompletedTask;
                });
            });
        }

        /// <summary>
        /// Adds a special handler that checks for responses with the 400 status code (bad request).
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline.</param>
        public static void UseOrderBadRequestResult(this IApplicationBuilder application)
        {
            application.UseStatusCodePages(context =>
            {
                //handle 404 (Bad request)
                if (context.HttpContext.Response.StatusCode == StatusCodes.Status400BadRequest)
                {
                    //    var logger = EngineContext.Current.Resolve<ILogger>();
                    //    var workContext = EngineContext.Current.Resolve<IWorkContext>();
                    //    logger.Error("Error 400. Bad request", null, customer: workContext.CurrentCustomer);
                }

                return Task.CompletedTask;
            });
        }

        /// <summary>
        /// Configure middleware for dynamically compressing HTTP responses.
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline.</param>
        public static void UseOrderResponseCompression(this IApplicationBuilder application)
        {
            //whether to use compression (gzip by default)
            application.UseResponseCompression();
        }

        /// <summary>
        /// Configure Endpoints routing.
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline.</param>
        public static void UseOrderEndpoints(this IApplicationBuilder application)
        {
            //Add the EndpointRoutingMiddleware
            application.UseRouting();

            //Execute the endpoint 
            application.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        /// <summary>
        /// The UseOrderSwaggerUI.
        /// </summary>
        /// <param name="application">The application<see cref="IApplicationBuilder"/>.</param>
        public static void UseOrderSwaggerUI(this IApplicationBuilder application)
        {
            application.UseSwagger();
            application.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "mShop.Ordering.Api v1"));
        }
    }
}
