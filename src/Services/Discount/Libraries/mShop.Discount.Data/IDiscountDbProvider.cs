using Microsoft.EntityFrameworkCore;

namespace mShop.Discount.Data
{
    /// <summary>
    /// Defines the <see cref="IDiscountDbProvider" />.
    /// </summary>
    public partial interface IDiscountDbProvider
    {
        /// <summary>
        /// Gets the DbContext.
        /// </summary>
        DbContext DbContext { get; }
    }
}
