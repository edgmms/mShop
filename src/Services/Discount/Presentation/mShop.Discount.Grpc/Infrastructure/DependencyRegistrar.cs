using Autofac;
using mShop.Core.Infrastructure;
using mShop.Core.Infrastructure.DependencyManagement;

namespace mShop.Discount.Grpc.Infrastructure
{
    public partial class DependencyRegistrar : IDependencyRegistrar
    {
        public int Order => 0;

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {

        }
    }
}
