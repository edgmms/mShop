namespace mShop.Catalog.Api.Models.Catalog
{
    /// <summary>
    /// Defines the <see cref="CategoryModel" />.
    /// </summary>
    public partial class CategoryModel : BaseEntityModel
    {
        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        public string Description { get; set; }
    }
}
