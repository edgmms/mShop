using Autofac;
using mShop.Basket.Core.Infrastructure;
using mShop.Basket.Core.Infrastructure.DependencyManagement;

namespace mShop.Basket.Data.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public int Order => -2;

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            //redis context
            builder.RegisterType<BasketDbProvider>().As<IBasketDbProvider>().InstancePerLifetimeScope();

            //basket repository
            builder.RegisterType<BasketRepository>().As<IBasketRepository>().InstancePerLifetimeScope();
        }
    }
}