using Autofac;
using mShop.Core.Infrastructure;
using mShop.Core.Infrastructure.DependencyManagement;

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
