using System.Collections.Generic;

namespace mShop.Catalog.Api.Models
{
    /// <summary>
    /// Represents a paged model
    /// </summary>
    public partial interface IPagedModel<T> where T : BaseModel
    {
        /// <summary>
        /// Gets or sets data records
        /// </summary>
        IEnumerable<T> Data { get; set; }

        /// <summary>
        /// Gets the TotalCount
        /// </summary>
        int TotalCount { get; set; }
    }
}
