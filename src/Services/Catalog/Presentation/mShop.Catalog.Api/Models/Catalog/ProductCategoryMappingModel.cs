namespace mShop.Catalog.Api.Models.Catalog
{
    /// <summary>
    /// Defines the <see cref="ProductCategoryMappingModel" />.
    /// </summary>
    public partial class ProductCategoryMappingModel
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
