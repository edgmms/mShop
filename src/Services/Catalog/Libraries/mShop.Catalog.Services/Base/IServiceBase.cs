using mShop.Catalog.Core;
using System.Threading.Tasks;

namespace mShop.Catalog.Services
{
    /// <summary>
    /// Defines the <see cref="IServiceBase{TEntity}" />.
    /// </summary>
    /// <typeparam name="TEntity">.</typeparam>
    public interface IServiceBase<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// The GetByIdAsync.
        /// </summary>
        /// <param name="id">The id<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{TEntity}"/>.</returns>
        Task<TEntity> GetByIdAsync(string id);

        /// <summary>
        /// The Insert.
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task InsertAsync(TEntity entity);

        /// <summary>
        /// The Update.
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task UpdateAsync(TEntity entity);

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task DeleteAsync(TEntity entity);

        /// <summary>
        /// The DeleteByIdAsync.
        /// </summary>
        /// <param name="id">The id<see cref="string"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task DeleteByIdAsync(string id);
    }
}
