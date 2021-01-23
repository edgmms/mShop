namespace mShop.Catalog.Core.Domain.Catalog
{
    /// <summary>
    /// Defines the <see cref="Product" />.
    /// </summary>
    public class Product : FullAuditedEntity
    {
        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the ShortDescription.
        /// </summary>
        public string ShortDescription { get; set; }

        /// <summary>
        /// Gets or sets the FullDescription.
        /// </summary>
        public string FullDescription { get; set; }

        /// <summary>
        /// Gets or sets the Quantity.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the Price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the OldPrice.
        /// </summary>
        public decimal OldPrice { get; set; }

        /// <summary>
        /// Gets or sets the ProductCost.
        /// </summary>
        public decimal ProductCost { get; set; }
    }
}
