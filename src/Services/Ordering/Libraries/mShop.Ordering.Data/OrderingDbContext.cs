using Microsoft.EntityFrameworkCore;
using mShop.Ordering.Data.Mappings;
using System;
using System.Linq;
using System.Reflection;

namespace mShop.Ordering.Data
{
    /// <summary>
    /// Defines the <see cref="OrderingDbContext" />.
    /// </summary>
    public partial class OrderingDbContext : DbContext, IOrderingDbProvider
    {
        /// <summary>
        /// Defines the _orderingDbSettings.
        /// </summary>
        private readonly OrderingDbSettings _orderingDbSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderingDbContext"/> class.
        /// </summary>
        /// <param name="orderingDbSettings">The orderingDbSettings<see cref="OrderingDbSettings"/>.</param>
        public OrderingDbContext(OrderingDbSettings orderingDbSettings)
        {
            _orderingDbSettings = orderingDbSettings;
        }

        /// <summary>
        /// Gets the DbContext.
        /// </summary>
        public DbContext DbContext { get => this; }

        /// <summary>
        /// The OnConfiguring.
        /// </summary>
        /// <param name="optionsBuilder">The optionsBuilder<see cref="DbContextOptionsBuilder"/>.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_orderingDbSettings.ConnectionString);
        }

        /// <summary>
        /// The OnModelCreating.
        /// Apply configuration of entities.
        /// </summary>
        /// <param name="modelBuilder">The modelBuilder<see cref="ModelBuilder"/>.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => !String.IsNullOrEmpty(type.Namespace))
                .Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
                type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfigurator<>));

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }
        }
    }
}
