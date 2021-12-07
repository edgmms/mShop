using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mShop.Discount.Core.Domain;

namespace mShop.Discount.Data.Mappings
{
    /// <summary>
    /// Defines the <see cref="CouponMapping" />.
    /// </summary>
    public partial class CouponMapping : EntityTypeConfigurator<Coupon>
    {
        /// <summary>
        /// The Configure.
        /// </summary>
        /// <param name="builder">The builder<see cref="EntityTypeBuilder{Coupon}"/>.</param>
        public override void Configure(EntityTypeBuilder<Coupon> builder)
        {
            builder.ToTable("Coupon");
            builder.HasKey(x => x.Id);
        }
    }
}