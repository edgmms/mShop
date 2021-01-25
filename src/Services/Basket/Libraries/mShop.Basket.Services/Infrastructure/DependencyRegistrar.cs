using Autofac;
using mShop.Basket.Core.Infrastructure;
using mShop.Basket.Core.Infrastructure.DependencyManagement;

namespace mShop.Basket.Services.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public int Order => -1;

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            builder.RegisterType<ShoppingCartService>().As<IShoppingCartService>().InstancePerLifetimeScope();
        }
    }
}
