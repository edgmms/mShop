namespace mShop.Basket.Api.Models.ShoppingCart
{
    /// <summary>
    /// Defines the <see cref="DeleteShoppingCartModel" />.
    /// </summary>
    public partial class DeleteShoppingCartModel : BaseEntityModel
    {
        /// <summary>
        /// Gets or sets the ShoppingCartTypeId.
        /// </summary>
        public int ShoppingCartTypeId { get; set; }
    }
}
