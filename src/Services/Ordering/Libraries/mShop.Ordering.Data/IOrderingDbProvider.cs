using Microsoft.EntityFrameworkCore;

namespace mShop.Ordering.Data
{
    /// <summary>
    /// Defines the <see cref="IOrderingDbProvider" />.
    /// </summary>
    public partial interface IOrderingDbProvider
    {
        /// <summary>
        /// Gets the DbContext.
        /// </summary>
        DbContext DbContext { get; }
    }
}
