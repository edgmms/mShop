namespace mShop.Catalog.Core.Domain.Catalog
{
    /// <summary>
    /// Defines the <see cref="ProductCategoryMapping" />.
    /// </summary>
    public partial class ProductCategoryMapping : BaseEntity
    {
        /// <summary>
        /// Gets or sets a value indicating whether FeaturedProduct.
        /// </summary>
        public bool FeaturedProduct { get; set; }

        /// <summary>
        /// Gets or sets the ProductId.
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// Gets or sets the CategoryId.
        /// </summary>
        public string CategoryId { get; set; }
    }
}
