using mShop.Basket.Core.Domain;
using System.Threading.Tasks;

namespace mShop.Basket.Services
{
    /// <summary>
    /// Defines the <see cref="IShoppingCartService" />.
    /// </summary>
    public partial interface IShoppingCartService
    {
        /// <summary>
        /// The GetShoppingCart.
        /// </summary>
        /// <param name="customerId">The customerId<see cref="int"/>.</param>
        /// <param name="shoppingCartType">The shoppingCartType<see cref="ShoppingCartType"/>.</param>
        /// <returns>The <see cref="Task{ShoppingCart}"/>.</returns>
        Task<ShoppingCart> GetShoppingCart(int customerId = 0, ShoppingCartType shoppingCartType = ShoppingCartType.ShoppingCart);

        /// <summary>
        /// The UpdateShoppingCart.
        /// </summary>
        /// <param name="shoppingCart">The shoppingCart<see cref="ShoppingCart"/>.</param>
        /// <param name="customerId">The customerId<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{ShoppingCart}"/>.</returns>
        Task<ShoppingCart> UpdateShoppingCart(ShoppingCart shoppingCart, int customerId);

        /// <summary>
        /// The DeleteShoppingCart.
        /// </summary>
        /// <param name="customerId">The customerId<see cref="int"/>.</param>
        /// <param name="shoppingCartType">The shoppingCartType<see cref="ShoppingCartType"/>.</param>
        /// <returns>The <see cref="Task{bool}"/>.</returns>
        Task<bool> DeleteShoppingCart(int customerId = 0, ShoppingCartType shoppingCartType = ShoppingCartType.ShoppingCart);
    }
}
