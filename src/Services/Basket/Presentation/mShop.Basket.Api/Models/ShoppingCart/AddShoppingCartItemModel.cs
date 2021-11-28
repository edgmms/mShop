using mShop.Basket.Core.Domain;
using System;

namespace mShop.Basket.Api.Models.ShoppingCart
{
    /// <summary>
    /// Defines the <see cref="AddShoppingCartItemModel" />.
    /// </summary>
    public partial class AddShoppingCartItemModel : BaseEntityModel
    {
        /// <summary>
        /// Gets or sets the product identifier.....
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the product variants (attributes) in XML format.....
        /// </summary>
        public string AttributesXml { get; set; }

        /// <summary>
        /// Gets or sets the price enter by a customer.....
        /// </summary>
        public decimal CustomerEnteredPrice { get; set; }

        /// <summary>
        /// Gets or sets the Quantity.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the UnitPriceExclTax.
        /// </summary>
        public decimal UnitPriceExclTax { get; set; }

        /// <summary>
        /// Gets or sets the UnitPriceInclTax.
        /// </summary>
        public decimal UnitPriceInclTax { get; set; }

        /// <summary>
        /// Gets or sets the DiscountedPriceExclTax.
        /// </summary>
        public decimal DiscountedPriceExclTax { get; set; }

        /// <summary>
        /// Gets or sets the DiscountedPriceInclTax.
        /// </summary>
        public decimal DiscountedPriceInclTax { get; set; }

        /// <summary>
        /// Gets or sets the TotalPriceExclTax.
        /// </summary>
        public decimal TotalPriceExclTax { get; set; }

        /// <summary>
        /// Gets or sets the TotalPriceInclTax.
        /// </summary>
        public decimal TotalPriceInclTax { get; set; }

        /// <summary>
        /// Gets or sets the date and time of instance creation.....
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time of instance update.....
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the ShoppingCartTypeId.
        /// </summary>
        public ShoppingCartType ShoppingCartType { get; set; }
    }
}
