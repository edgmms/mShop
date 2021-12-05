using Autofac;
using mShop.Core.Infrastructure;
using mShop.Core.Infrastructure.DependencyManagement;

namespace mShop.Basket.Data.Infrastructure
{
    /// <summary>
    /// Defines the <see cref="DependencyRegistrar" />.
    /// </summary>
    public partial class DependencyRegistrar : IDependencyRegistrar
    {
        /// <summary>
        /// Gets the Order.
        /// </summary>
        public int Order => -2;

        /// <summary>
        /// The Register.
        /// </summary>
        /// <param name="builder">The builder<see cref="ContainerBuilder"/>.</param>
        /// <param name="typeFinder">The typeFinder<see cref="ITypeFinder"/>.</param>
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            //redis context
            builder.RegisterType<RedisDbInitializer>().As<IDbInitializer>().InstancePerLifetimeScope();

            //redis context
            builder.RegisterType<BasketDbProvider>().As<IBasketDbProvider>().InstancePerLifetimeScope();

            //basket repository
            builder.RegisterType<BasketRepository>().As<IBasketRepository>().InstancePerLifetimeScope();
        }
    }
}
