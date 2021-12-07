using Microsoft.EntityFrameworkCore;
using mShop.Discount.Data.Mappings;
using System;
using System.Linq;
using System.Reflection;

namespace mShop.Discount.Data
{
    /// <summary>
    /// Defines the <see cref="DiscountDbContext" />.
    /// </summary>
    public partial class DiscountDbContext : DbContext, IDiscountDbProvider
    {
        /// <summary>
        /// Defines the _discountDbSettings.
        /// </summary>
        private readonly DiscountDbSettings _discountDbSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="DiscountDbContext"/> class.
        /// </summary>
        /// <param name="discountDbSettings">The discountDbSettings<see cref="DiscountDbSettings"/>.</param>
        public DiscountDbContext(DiscountDbSettings discountDbSettings)
        {
            _discountDbSettings = discountDbSettings;
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
            optionsBuilder.UseNpgsql(_discountDbSettings.ConnectionString);
        }

        /// <summary>
        /// The OnModelCreating.
        /// Apply configuration of entities
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
