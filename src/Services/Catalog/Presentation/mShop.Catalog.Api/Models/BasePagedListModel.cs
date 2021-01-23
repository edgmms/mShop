using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mShop.Catalog.Api.Models
{
    /// <summary>
    /// Represents the base paged list model 
    /// </summary>
    public abstract partial class BasePagedListModel<T> : BaseModel, IPagedModel<T> where T : BaseModel
    {
        /// <summary>
        /// Gets or sets data records
        /// </summary>
        public IEnumerable<T> Data { get; set; }
    
        /// <summary>
        /// Gets the TotalCount
        /// Total count.
        /// </summary>
        public int TotalCount { get; set; }
    }
}
