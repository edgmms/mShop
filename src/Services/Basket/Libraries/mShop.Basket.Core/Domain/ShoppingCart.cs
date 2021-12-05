using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace mShop.Basket.Core.Domain
{
    /// <summary>
    /// Defines the <see cref="ShoppingCart" />.
    /// </summary>
    public partial class ShoppingCart : BaseEntity
    {
        /// <summary>
        /// Gets or sets the shopping cart type identifier.
        /// </summary>
        public int ShoppingCartTypeId { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the ShoppingCartType
        /// Gets the log type.
        /// </summary> 
        public ShoppingCartType ShoppingCartType { get => (ShoppingCartType)ShoppingCartTypeId; set => ShoppingCartTypeId = (int)value; }

        /// <summary>
        /// Gets or sets the ShoppingCartItems.
        /// </summary>
        public virtual List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
