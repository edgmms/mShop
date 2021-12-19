using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using mShop.Core.Infrastructure;
using mShop.Discount.Grpc.Services;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;

namespace mShop.Discount.Grpc.Infrastructure.StartupExtensions
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
        /// Configure Endpoints routing.
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline.</param>
        public static void UseDiscountEndpoints(this IApplicationBuilder application)
        {
            //Add the EndpointRoutingMiddleware
            application.UseRouting();

            //Execute the endpoint 
            application.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<DiscountService>();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                });
            });
        }
    }
}
