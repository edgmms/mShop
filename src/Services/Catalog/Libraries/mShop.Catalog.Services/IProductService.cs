using mShop.Catalog.Core.Domain.Catalog;
using mShop.Core;

namespace mShop.Catalog.Services
{
    /// <summary>
    /// Defines the <see cref="IProductService" />.
    /// </summary>
    public interface IProductService : IServiceBase<Product>
    {
        /// <summary>
        /// The SearchProducts.
        /// </summary>
        /// <param name="productName">The productName<see cref="string"/>.</param>
        /// <param name="pageIndex">The pageIndex<see cref="int"/>.</param>
        /// <param name="pageSize">The pageSize<see cref="int"/>.</param>
        /// <param name="loadOnlyTotalCount">The loadOnlyTotalCount<see cref="bool"/>.</param>
        /// <returns>The <see cref="IPagedList{Product}"/>.</returns>
        IPagedList<Product> SearchProducts(string productName = "", int pageIndex = 0,
            int pageSize = int.MaxValue, bool loadOnlyTotalCount = false);
    }
}
