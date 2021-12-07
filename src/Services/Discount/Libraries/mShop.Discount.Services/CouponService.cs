using mShop.Discount.Core.Domain;
using mShop.Discount.Data;
using System.Linq;

namespace mShop.Discount.Services
{
    /// <summary>
    /// Defines the <see cref="CouponService" />.
    /// </summary>
    public partial class CouponService : ICouponService
    {
        /// <summary>
        /// Defines the _couponRepository.
        /// </summary>
        private readonly IRepository<Coupon> _couponRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CouponService"/> class.
        /// </summary>
        /// <param name="couponRepository">The couponRepository<see cref="IRepository{Coupon}"/>.</param>
        public CouponService(IRepository<Coupon> couponRepository)
        {
            _couponRepository = couponRepository;
        }

        /// <summary>
        /// The GetCouponById.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="Coupon"/>.</returns>
        public Coupon GetCouponById(int id = 0)
        {
            var coupon = _couponRepository.GetById(id);
            return coupon;
        }

        /// <summary>
        /// The GetCouponByProductId.
        /// </summary>
        /// <param name="productId">The productId<see cref="int"/>.</param>
        /// <returns>The <see cref="Coupon"/>.</returns>
        public Coupon GetCouponByProductId(int productId = 0)
        {
            var coupon = _couponRepository.Table.FirstOrDefault(x => x.ProductId == productId);
            return coupon;
        }
    }
}
