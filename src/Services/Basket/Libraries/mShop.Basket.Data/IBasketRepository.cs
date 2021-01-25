using mShop.Basket.Core.Domain;
using System.Threading.Tasks;

namespace mShop.Basket.Data
{
    /// <summary>
    /// Defines the <see cref="IBasketRepository" />.
    /// </summary>
    public partial interface IBasketRepository
    {
        /// <summary>
        /// The GetShoppingCart.
        /// </summary>
        /// <param name="customerId">The customerId<see cref="int"/>.</param>
        /// <param name="shoppingCartType">The shoppingCartType<see cref="ShoppingCartType"/>.</param>
        /// <returns>The <see cref="Task{ShoppingCart}"/>.</returns>
        Task<ShoppingCart> GetShoppingCart(int customerId, ShoppingCartType shoppingCartType = ShoppingCartType.ShoppingCart);

        /// <summary>
        /// The UpdateShoppingCart.
        /// </summary>
        /// <param name="customerId">The customerId<see cref="int"/>.</param>
        /// <param name="shoppingCart">The shoppingCart<see cref="ShoppingCart"/>.</param>
        /// <returns>The <see cref="Task{ShoppingCart}"/>.</returns>
        Task<ShoppingCart> UpdateShoppingCart(int customerId, ShoppingCart shoppingCart);

        /// <summary>
        /// The DeleteShoppingCart.
        /// </summary>
        /// <param name="customerId">The customerId<see cref="int"/>.</param>
        /// <param name="shoppingCartType">The shoppingCartType<see cref="ShoppingCartType"/>.</param>
        /// <returns>The <see cref="Task{ShoppingCart}"/>.</returns>
        Task<bool> DeleteShoppingCart(int customerId, ShoppingCartType shoppingCartType = ShoppingCartType.ShoppingCart);
    }
}
