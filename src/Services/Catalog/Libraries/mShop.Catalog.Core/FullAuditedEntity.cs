using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace mShop.Catalog.Core
{
    /// <summary>
    /// Defines the <see cref="FullAuditedEntity" />.
    /// </summary>
    public class FullAuditedEntity : BaseEntity
    {
        /// <summary>
        /// Gets or sets the CreatedById.
        /// </summary>
        [BsonRepresentation(BsonType.Int32)]
        [BsonElement(Order = 101)]
        public int CreatedById { get; set; }

        /// <summary>
        /// Gets or sets the CreatedOnUtc.
        /// </summary>
        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        [BsonElement(Order = 102)]
        public DateTime CreatedOnUtc { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets or sets the UpdatedById.
        /// </summary>
        [BsonRepresentation(BsonType.Int32)]
        [BsonElement(Order = 103)]
        public int UpdatedById { get; set; }

        /// <summary>
        /// Gets or sets the UpdatedOnUtc.
        /// </summary>
        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        [BsonElement(Order = 104)]
        public DateTime UpdatedOnUtc { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets or sets the DeletedById.
        /// </summary>
        [BsonRepresentation(BsonType.Int32)]
        [BsonElement(Order = 103)]
        public int DeletedById { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Deleted.
        /// </summary>
        [BsonRepresentation(BsonType.Boolean)]
        [BsonElement(Order = 105)]
        public bool Deleted { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Active.
        /// </summary>
        [BsonRepresentation(BsonType.Boolean)]
        [BsonElement(Order = 106)]
        public bool Active { get; set; }
    }
}
