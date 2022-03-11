using mShop.Basket.Core.Domain;
using System;
using System.Collections.Generic;

namespace mShop.Basket.Data.Infrastructure
{
    /// <summary>
    /// Defines the <see cref="CatalogDbSeeder" />.
    /// </summary>
    public partial class RedisDbInitializer : IDbInitializer
    {
        /// <summary>
        /// Defines the _basketRepository.
        /// </summary>
        private readonly IBasketRepository _basketRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RedisDbInitializer"/> class.
        /// </summary>
        /// <param name="basketRepository">The basketRepository<see cref="IBasketRepository"/>.</param>
        public RedisDbInitializer(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        /// <summary>
        /// The SeedData.
        /// </summary>
        public void Initialize()
        {
            try
            {
                var seedData = SeedShoppingCarts();
                _basketRepository.UpdateShoppingCart(1, seedData);
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// The SeedProducts.
        /// </summary>
        /// <returns>The <see cref="IEnumerable{Product}"/>.</returns>
        private static ShoppingCart SeedShoppingCarts()
        {
            return
                new ShoppingCart
                {
                    CustomerId = 1,
                    ShoppingCartTypeId = (int)ShoppingCartType.ShoppingCart,
                    ShoppingCartItems = new List<ShoppingCartItem>()
                     {
                         new ShoppingCartItem
                         {
                              AttributesXml = string.Empty,
                              Quantity = 1,
                              ProductId = 1,
                              UnitPriceExclTax = 100,
                              UnitPriceInclTax = 118,
                              DiscountedPriceExclTax = 100,
                              DiscountedPriceInclTax = 118,
                              TotalPriceExclTax = 100,
                              TotalPriceInclTax = 118,
                              CreatedOnUtc = DateTime.UtcNow,
                              UpdatedOnUtc = DateTime.UtcNow
                         },
                         new ShoppingCartItem
                         {
                              AttributesXml = string.Empty,
                              Quantity = 1,
                              ProductId = 2,
                              UnitPriceExclTax = 100,
                              UnitPriceInclTax = 118,
                              DiscountedPriceExclTax = 100,
                              DiscountedPriceInclTax = 118,
                              TotalPriceExclTax = 100,
                              TotalPriceInclTax = 118,
                              CreatedOnUtc = DateTime.UtcNow,
                              UpdatedOnUtc = DateTime.UtcNow
                         },
                          new ShoppingCartItem
                         {
                             AttributesXml = string.Empty,
                              Quantity = 1,
                              ProductId = 3,
                              UnitPriceExclTax = 100,
                              UnitPriceInclTax = 118,
                              DiscountedPriceExclTax = 100,
                              DiscountedPriceInclTax = 118,
                              TotalPriceExclTax = 100,
                              TotalPriceInclTax = 118,
                              CreatedOnUtc = DateTime.UtcNow,
                              UpdatedOnUtc = DateTime.UtcNow
                         }
                     }
                };
        }
    }
}
