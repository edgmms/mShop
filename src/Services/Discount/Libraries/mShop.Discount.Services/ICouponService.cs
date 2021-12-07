using mShop.Discount.Core.Domain;

namespace mShop.Discount.Services
{
    /// <summary>
    /// Defines the <see cref="ICouponService" />.
    /// </summary>
    public partial interface ICouponService
    {
        /// <summary>
        /// The GetCouponById.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="Coupon"/>.</returns>
        Coupon GetCouponById(int id = 0);

        /// <summary>
        /// The GetCouponByProductId.
        /// </summary>
        /// <param name="productId">The productId<see cref="int"/>.</param>
        /// <returns>The <see cref="Coupon"/>.</returns>
        Coupon GetCouponByProductId(int productId = 0);
    }
}
