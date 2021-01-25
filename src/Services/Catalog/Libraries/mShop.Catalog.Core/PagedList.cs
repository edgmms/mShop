using System;
using System.Collections.Generic;
using System.Linq;

namespace mShop.Catalog.Core
{
    /// <summary>
    /// Paged list.
    /// </summary>
    /// <typeparam name="T">T.</typeparam>
    [Serializable]
    public class PagedList<T> : List<T>, IPagedList<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PagedList{T}"/> class.
        /// </summary>
        /// <param name="source">source.</param>
        /// <param name="pageIndex">Page index.</param>
        /// <param name="pageSize">Page size.</param>
        /// <param name="getOnlyTotalCount">A value in indicating whether you want to load only total number of records. Set to "true" if you don't want to load data from database.</param>
        public PagedList(IQueryable<T> source, int pageIndex, int pageSize, bool getOnlyTotalCount = false)
        {
            var total = source.Count();
            TotalCount = total;
            TotalPages = total / pageSize;

            if (total % pageSize > 0)
                TotalPages++;

            PageSize = pageSize;
            PageIndex = pageIndex;
            if (getOnlyTotalCount)
                return;
            AddRange(source.Skip(pageIndex * pageSize).Take(pageSize).ToList());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedList{T}"/> class.
        /// </summary>
        /// <param name="source">source.</param>
        /// <param name="pageIndex">Page index.</param>
        /// <param name="pageSize">Page size.</param>
        public PagedList(IList<T> source, int pageIndex, int pageSize)
        {
            TotalCount = source.Count;
            TotalPages = TotalCount / pageSize;

            if (TotalCount % pageSize > 0)
                TotalPages++;

            PageSize = pageSize;
            PageIndex = pageIndex;
            AddRange(source.Skip(pageIndex * pageSize).Take(pageSize).ToList());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedList{T}"/> class.
        /// </summary>
        /// <param name="source">source.</param>
        /// <param name="pageIndex">Page index.</param>
        /// <param name="pageSize">Page size.</param>
        /// <param name="totalCount">Total count.</param>
        public PagedList(IEnumerable<T> source, int pageIndex, int pageSize, int totalCount)
        {
            TotalCount = totalCount;
            TotalPages = TotalCount / pageSize;

            if (TotalCount % pageSize > 0)
                TotalPages++;

            PageSize = pageSize;
            PageIndex = pageIndex;
            AddRange(source);
        }

        /// <summary>
        /// Gets the PageIndex
        /// Page index.
        /// </summary>
        public int PageIndex { get; }

        /// <summary>
        /// Gets the PageSize
        /// Page size.
        /// </summary>
        public int PageSize { get; }

        /// <summary>
        /// Gets the TotalCount
        /// Total count.
        /// </summary>
        public int TotalCount { get; }

        /// <summary>
        /// Gets the TotalPages
        /// Total pages.
        /// </summary>
        public int TotalPages { get; }

        /// <summary>
        /// Gets a value indicating whether HasPreviousPage
        /// Has previous page.
        /// </summary>
        public bool HasPreviousPage => PageIndex > 0;

        /// <summary>
        /// Gets a value indicating whether HasNextPage
        /// Has next page.
        /// </summary>
        public bool HasNextPage => PageIndex + 1 < TotalPages;
    }
}
