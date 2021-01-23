using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace mShop.Catalog.Core
{
    /// <summary>
    /// Defines the <see cref="BaseEntity" />.
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
