using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mShop.Ordering.Core.Domain.Orders;

namespace mShop.Ordering.Data.Mappings
{
    /// <summary>
    /// Defines the <see cref="OrderMapping" />.
    /// </summary>
    public partial class OrderMapping : EntityTypeConfigurator<Order>
    {
        /// <summary>
        /// The Configure.
        /// </summary>
        /// <param name="builder">The builder<see cref="EntityTypeBuilder{Order}"/>.</param>
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
            builder.HasKey(x => x.Id);
        }
    }
}