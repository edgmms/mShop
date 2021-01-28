using Autofac;
using mShop.Core.Infrastructure;
using mShop.Core.Infrastructure.DependencyManagement;

namespace mShop.Catalog.Services.Infrastructure
{
    /// <summary>
    /// Defines the <see cref="DependencyRegistrar" />.
    /// </summary>
    public class DependencyRegistrar : IDependencyRegistrar
    {
        /// <summary>
        /// Gets the Order.
        /// </summary>
        public int Order => -1;

        /// <summary>
        /// The Register.
        /// </summary>
        /// <param name="builder">The builder<see cref="ContainerBuilder"/>.</param>
        /// <param name="typeFinder">The typeFinder<see cref="ITypeFinder"/>.</param>
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            builder.RegisterGeneric(typeof(ServiceBase<>)).As(typeof(IServiceBase<>)).InstancePerLifetimeScope();

            builder.RegisterType<ProductService>().As<IProductService>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerLifetimeScope();
        }
    }
}
