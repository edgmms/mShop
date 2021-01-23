using Autofac;
using mShop.Catalog.Core.Infrastructure;
using mShop.Catalog.Core.Infrastructure.DependencyManagement;

namespace mShop.Catalog.Data.Infrastructure
{
    /// <summary>
    /// Defines the <see cref="DependencyRegistrar" />.
    /// </summary>
    public class DependencyRegistrar : IDependencyRegistrar
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
            builder.RegisterType<MongoDbInitializer>().As<IDbInitializer>().InstancePerLifetimeScope();

            //repositories
            builder.RegisterGeneric(typeof(GenericMongoRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
        }
    }
}
