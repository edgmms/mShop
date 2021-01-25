using mShop.Basket.Core.Domain;
using mShop.Basket.Data;
using System;
using System.Threading.Tasks;

namespace mShop.Basket.Services
{
    /// <summary>
    /// Defines the <see cref="ShoppingCartService" />.
    /// </summary>
    public partial class ShoppingCartService : IShoppingCartService
    {
        /// <summary>
        /// Defines the _basketRepository.
        /// </summary>
        private readonly IBasketRepository _basketRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingCartService"/> class.
        /// </summary>
        /// <param name="basketRepository">The basketRepository<see cref="IBasketRepository"/>.</param>
        public ShoppingCartService(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        /// <summary>
        /// The GetShoppingCart.
        /// </summary>
        /// <param name="customerId">The customerId<see cref="int"/>.</param>
        /// <param name="shoppingCartType">The shoppingCartType<see cref="ShoppingCartType"/>.</param>
        /// <returns>The <see cref="Task{ShoppingCart}"/>.</returns>
        public virtual async Task<ShoppingCart> GetShoppingCart(int customerId = 0, ShoppingCartType shoppingCartType = ShoppingCartType.ShoppingCart)
        {
            if (customerId == 0)
                throw new ArgumentNullException(nameof(customerId));

            return await _basketRepository.GetShoppingCart(customerId, shoppingCartType);
        }

        /// <summary>
        /// The UpdateShoppingCart.
        /// </summary>
        /// <param name="shoppingCart">The shoppingCart<see cref="ShoppingCart"/>.</param>
        /// <param name="customerId">The customerId<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{ShoppingCart}"/>.</returns>
        public virtual async Task<ShoppingCart> UpdateShoppingCart(ShoppingCart shoppingCart, int customerId)
        {
            if (shoppingCart == null)
                throw new ArgumentNullException(nameof(shoppingCart));

            if (customerId == 0)
                throw new ArgumentNullException(nameof(customerId));

            return await _basketRepository.UpdateShoppingCart(customerId, shoppingCart);
        }

        /// <summary>
        /// The DeleteShoppingCart.
        /// </summary>
        /// <param name="customerId">The customerId<see cref="int"/>.</param>
        /// <param name="shoppingCartType">The shoppingCartType<see cref="ShoppingCartType"/>.</param>
        /// <returns>The <see cref="Task{bool}"/>.</returns>
        public virtual async Task<bool> DeleteShoppingCart(int customerId = 0, ShoppingCartType shoppingCartType = ShoppingCartType.ShoppingCart)
        {
            if (customerId == 0)
                throw new ArgumentNullException(nameof(customerId));

            return await _basketRepository.DeleteShoppingCart(customerId, shoppingCartType);
        }
    }
}
