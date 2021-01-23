using MongoDB.Bson.Serialization.Attributes;

namespace mShop.Catalog.Core.Domain.Catalog
{
    /// <summary>
    /// Defines the <see cref="Category" />.
    /// </summary>
    public class Category : FullAuditedEntity
    {
        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        [BsonElement("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        public string Description { get; set; }
    }
}
