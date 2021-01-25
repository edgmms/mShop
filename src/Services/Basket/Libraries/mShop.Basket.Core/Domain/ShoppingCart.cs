using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace mShop.Basket.Core.Domain
{
    public class ShoppingCart : BaseEntity
    {
        private ICollection<ShoppingCartItem> _shoppingCartItems;

        public virtual ICollection<ShoppingCartItem> ShoppingCartItems
        {
            get { return _shoppingCartItems ?? new List<ShoppingCartItem>(); }
            set { _shoppingCartItems = value; }
        }

        /// <summary>
        /// Gets or sets the shopping cart type identifier
        /// </summary>
        public int ShoppingCartTypeId { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets the log type
        /// </summary>
        [JsonIgnore]
        [XmlIgnore]
        public ShoppingCartType ShoppingCartType
        {
            get => (ShoppingCartType)ShoppingCartTypeId;
            set => ShoppingCartTypeId = (int)value;
        }
    }
}

