using mShop.Discount.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace mShop.Discount.Data.Infrastructure
{
    /// <summary>
    /// Defines the <see cref="PostgreDbInitializer" />.
    /// </summary>
    public partial class PostgreDbInitializer : IDbInitializer
    {
        /// <summary>
        /// Defines the _discountDbProvider.
        /// </summary>
        private readonly IDiscountDbProvider _discountDbProvider;

        /// <summary>
        /// Defines the _couponRepository.
        /// </summary>
        private readonly IRepository<Coupon> _couponRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PostgreDbInitializer"/> class.
        /// </summary>
        /// <param name="discountDbProvider">The discountDbProvider<see cref="IDiscountDbProvider"/>.</param>
        /// <param name="couponRepository">The couponRepository<see cref="IRepository{Coupon}"/>.</param>
        public PostgreDbInitializer(IDiscountDbProvider discountDbProvider, IRepository<Coupon> couponRepository)
        {
            _discountDbProvider = discountDbProvider;
            _couponRepository = couponRepository;
        }

        /// <summary>
        /// The Initialize.
        /// </summary>
        public void Initialize()
        {
            try
            {

                _discountDbProvider.DbContext.Database.EnsureCreated();

                if (_couponRepository.Table.Count() == 0)
                {
                    _couponRepository.InsertRange(SeedCoupons());
                }
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// The SeedCoupons.
        /// </summary>
        /// <returns>The <see cref="IEnumerable{Coupon}"/>.</returns>
        private static IEnumerable<Coupon> SeedCoupons()
        {
            return new List<Coupon> {
                 new Coupon
                 {
                      Id = 1,
                      Amount = 10,
                      Description = "10 ₺ indirim",
                      ProductId = 1
                 },
                 new Coupon
                 {
                      Id=2,
                      Amount = 20,
                      Description = "20 ₺ indirim",
                      ProductId = 2
                 },
                 new Coupon
                 {
                      Id=3,
                      Amount = 30,
                      Description = "30 ₺ indirim",
                      ProductId = 3
                 }
            };
        }
    }
}
