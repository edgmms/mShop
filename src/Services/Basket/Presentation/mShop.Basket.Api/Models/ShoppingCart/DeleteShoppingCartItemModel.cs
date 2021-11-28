using mShop.Basket.Core.Domain;

namespace mShop.Basket.Api.Models.ShoppingCart
{
    /// <summary>
    /// Defines the <see cref="DeleteShoppingCartItemModel" />.
    /// </summary>
    public class DeleteShoppingCartItemModel : BaseEntityModel
    {
        /// <summary>
        /// Gets or sets the ProductId.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the ShoppingCartType.
        /// </summary>
        public ShoppingCartType ShoppingCartType { get; set; }
    }
}
