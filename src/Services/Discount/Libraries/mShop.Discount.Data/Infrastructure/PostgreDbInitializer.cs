using mShop.Discount.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace mShop.Discount.Data.Infrastructure
{
    /// <summary>
    /// Defines the <see cref="CatalogDbSeeder" />.
    /// </summary>
    public partial class PostgreDbInitializer : IDbInitializer
    {
        /// <summary>
        /// Defines the _couponRepository.
        /// </summary>
        private readonly IRepository<Coupon> _couponRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PostgreDbInitializer"/> class.
        /// </summary>
        /// <param name="couponRepository">The couponRepository<see cref="IRepository{Coupon}"/>.</param>
        public PostgreDbInitializer(IRepository<Coupon> couponRepository)
        {
            _couponRepository = couponRepository;
        }

        /// <summary>
        /// The SeedData.
        /// </summary>
        public void Initialize()
        {
            try
            {
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
        /// The SeedProducts.
        /// </summary>
        /// <returns>The <see cref="IEnumerable{Product}"/>.</returns>
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
