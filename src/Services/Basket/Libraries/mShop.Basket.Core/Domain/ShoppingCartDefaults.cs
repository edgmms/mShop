namespace mShop.Basket.Core.Domain
{
    /// <summary>
    /// Defines the <see cref="ShoppingCartDefaults" />.
    /// </summary>
    public static class ShoppingCartDefaults
    {
        /// <summary>
        /// Defines the ShoppingCartPrefix.
        /// </summary>
        public const string ShoppingCartPrefix = "mShop.Basket.ShoppingCart.";

        /// <summary>
        /// Defines the ShoppingCartKey.
        /// 0 : represent customer identifier
        /// 1 : represent shopping cart type Cart or Wishlist
        /// </summary>
        public const string ShoppingCartKey = "mShop.Basket.ShoppingCart.Customer-{0}.CartType-{1}";
    }
}
