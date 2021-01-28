using Autofac;
using mShop.Catalog.Core.Caching;
using mShop.Core.Infrastructure;
using mShop.Core.Infrastructure.DependencyManagement;

namespace mShop.Catalog.Core.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public int Order => -3;

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            //register cache manager
            builder.RegisterType<MemoryCacheManager>().As<ICacheManager>();
        }
    }
}
