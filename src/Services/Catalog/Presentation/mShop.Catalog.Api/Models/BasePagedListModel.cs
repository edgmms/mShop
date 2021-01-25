using System.Collections.Generic;

namespace mShop.Catalog.Api.Models
{
    /// <summary>
    /// Represents the base paged list model.
    /// </summary>
    /// <typeparam name="T">.</typeparam>
    public abstract partial class BasePagedListModel<T> : BaseModel, IPagedModel<T> where T : BaseModel
    {
        /// <summary>
        /// Gets or sets the Data.
        /// </summary>
        public IEnumerable<T> Data { get; set; }

        /// <summary>
        /// Gets or sets the TotalCount
        /// </summary>
        public int TotalCount { get; set; }
    }
}
