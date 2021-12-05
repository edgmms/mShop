using mShop.Discount.Core;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace mShop.Discount.Data
{
    /// <summary>
    /// Defines the <see cref="IRepository{TEntity}" />.
    /// </summary>
    /// <typeparam name="TEntity">.</typeparam>
    public partial interface IRepository<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// Gets the Table.
        /// </summary>
        IQueryable<TEntity> Table { get; }

        /// <summary>
        /// The GetByIdAsync.
        /// </summary>
        /// <param name="id">The id<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{TEntity}"/>.</returns>
        Task<TEntity> GetByIdAsync(int id);

        /// <summary>
        /// The InsertAsync.
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/>.</param>
        /// <returns>The <see cref="Task{TEntity}"/>.</returns>
        Task<TEntity> InsertAsync(TEntity entity);

        /// <summary>
        /// The UpdateAsync.
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/>.</param>
        /// <returns>The <see cref="Task{TEntity}"/>.</returns>
        Task<TEntity> UpdateAsync(TEntity entity);

        /// <summary>
        /// The DeleteAsync.
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/>.</param>
        /// <returns>The <see cref="Task{TEntity}"/>.</returns>
        Task<TEntity> DeleteAsync(TEntity entity);

        /// <summary>
        /// The DeleteAsync.
        /// </summary>
        /// <param name="id">The id<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{TEntity}"/>.</returns>
        Task<TEntity> DeleteAsync(int id);
    }
}
