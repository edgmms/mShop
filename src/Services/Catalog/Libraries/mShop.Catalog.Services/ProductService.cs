using mShop.Catalog.Core;
using mShop.Catalog.Core.Domain.Catalog;
using System.Linq;

namespace mShop.Catalog.Services
{
    /// <summary>
    /// Defines the <see cref="ProductService" />.
    /// </summary>
    public class ProductService : ServiceBase<Product>, IProductService
    {
        /// <summary>
        /// The SearchProducts.
        /// </summary>
        /// <param name="productName">The productName<see cref="string"/>.</param>
        /// <param name="pageIndex">The pageIndex<see cref="int"/>.</param>
        /// <param name="pageSize">The pageSize<see cref="int"/>.</param>
        /// <param name="loadOnlyTotalCount">The loadOnlyTotalCount<see cref="bool"/>.</param>
        /// <returns>The <see cref="IPagedList{Product}"/>.</returns>
        public IPagedList<Product> SearchProducts(string productName = "", int pageIndex = 0, int pageSize = int.MaxValue, bool loadOnlyTotalCount = false)
        {
            var query = base._repository.Table;

            if (!string.IsNullOrEmpty(productName))
                query = query.Where(p => p.Name == productName);

            query = query.OrderBy(p => p.Id);

            var data = new PagedList<Product>(query, pageIndex, pageSize, loadOnlyTotalCount);

            return data;
        }
    }
}
