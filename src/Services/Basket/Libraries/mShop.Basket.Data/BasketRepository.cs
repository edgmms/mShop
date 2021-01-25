using mShop.Basket.Core.Domain;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace mShop.Basket.Data
{
    /// <summary>
    /// Defines the <see cref="BasketRepository" />.
    /// </summary>
    public class BasketRepository : IBasketRepository
    {
        /// <summary>
        /// Defines the _basketDbProvider.
        /// </summary>
        private readonly IBasketDbProvider _basketDbProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="BasketRepository"/> class.
        /// </summary>
        /// <param name="basketDbProvider">The basketDbProvider<see cref="IBasketDbProvider"/>.</param>
        public BasketRepository(IBasketDbProvider basketDbProvider)
        {
            _basketDbProvider = basketDbProvider;
        }

        /// <summary>
        /// The GetShoppingCart.
        /// </summary>
        /// <param name="customerId">The customerId<see cref="int"/>.</param>
        /// <param name="shoppingCartType">The shoppingCartType<see cref="ShoppingCartType"/>.</param>
        /// <returns>The <see cref="Task{ShoppingCart}"/>.</returns>
        public virtual async Task<ShoppingCart> GetShoppingCart(int customerId, ShoppingCartType shoppingCartType = ShoppingCartType.ShoppingCart)
        {
            var key = string.Format(ShoppingCartDefaults.ShoppingCartKey, customerId, (int)shoppingCartType);

            var cart = await _basketDbProvider.GetDatabase().StringGetAsync(key);

            if (cart.IsNullOrEmpty)
                return null;

            return JsonConvert.DeserializeObject<ShoppingCart>(cart);
        }

        /// <summary>
        /// The UpdateShoppingCart.
        /// </summary>
        /// <param name="customerId">The customerId<see cref="int"/>.</param>
        /// <param name="shoppingCart">The shoppingCart<see cref="ShoppingCart"/>.</param>
        /// <returns>The <see cref="Task{ShoppingCart}"/>.</returns>
        public virtual async Task<ShoppingCart> UpdateShoppingCart(int customerId, ShoppingCart shoppingCart)
        {
            var key = string.Format(ShoppingCartDefaults.ShoppingCartKey, customerId, shoppingCart.ShoppingCartTypeId);

            var updated = await _basketDbProvider.GetDatabase().StringSetAsync(key, JsonConvert.SerializeObject(shoppingCart));

            if (!updated)
                return null;

            return await GetShoppingCart(customerId, shoppingCart.ShoppingCartType);
        }

        /// <summary>
        /// The DeleteShoppingCart.
        /// </summary>
        /// <param name="customerId">The customerId<see cref="int"/>.</param>
        /// <param name="shoppingCartType">The shoppingCartType<see cref="ShoppingCartType"/>.</param>
        /// <returns>The <see cref="Task{bool}"/>.</returns>
        public virtual async Task<bool> DeleteShoppingCart(int customerId, ShoppingCartType shoppingCartType = ShoppingCartType.ShoppingCart)
        {
            var key = string.Format(ShoppingCartDefaults.ShoppingCartKey, customerId, (int)shoppingCartType);

            return await _basketDbProvider.GetDatabase().KeyDeleteAsync(key);
        }
    }
}
