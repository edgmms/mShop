using System;

namespace mShop.Catalog.Api.Models
{
    /// <summary>
    /// Defines the <see cref="BaseFullAuditedEntityModel" />.
    /// </summary>
    public partial class BaseFullAuditedEntityModel : BaseEntityModel
    {
        /// <summary>
        /// Gets or sets the CreatedById.
        /// </summary>
        public int CreatedById { get; set; }

        /// <summary>
        /// Gets or sets the CreatedOnUtc.
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the UpdatedById.
        /// </summary>
        public int UpdatedById { get; set; }

        /// <summary>
        /// Gets or sets the UpdatedOnUtc.
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the DeletedById.
        /// </summary>
        public int DeletedById { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Deleted.
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Active.
        /// </summary>
        public bool Active { get; set; }
    }
}
