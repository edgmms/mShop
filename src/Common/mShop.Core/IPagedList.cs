using System.Collections.Generic;

namespace mShop.Core
{
    /// <summary>
    /// Paged list interface.
    /// </summary>
    /// <typeparam name="T">.</typeparam>
    public partial interface IPagedList<T> : IList<T>
    {
        /// <summary>
        /// Gets the PageIndex
        /// Page index.
        /// </summary>
        int PageIndex { get; }

        /// <summary>
        /// Gets the PageSize
        /// Page size.
        /// </summary>
        int PageSize { get; }

        /// <summary>
        /// Gets the TotalCount
        /// Total count.
        /// </summary>
        int TotalCount { get; }

        /// <summary>
        /// Gets the TotalPages
        /// Total pages.
        /// </summary>
        int TotalPages { get; }

        /// <summary>
        /// Gets the HasPreviousPage
        /// Has previous page.
        /// </summary>
        bool HasPreviousPage { get; }

        /// <summary>
        /// Gets the HasNextPage
        /// Has next age.
        /// </summary>
        bool HasNextPage { get; }
    }
}
