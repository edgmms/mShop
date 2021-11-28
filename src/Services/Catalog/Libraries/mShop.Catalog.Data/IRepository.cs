using mShop.Catalog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace mShop.Catalog.Data
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
        /// The Get.
        /// </summary>
        /// <param name="predicate">The predicate<see cref="Expression{Func{TEntity, bool}}"/>.</param>
        /// <returns>The <see cref="IQueryable{TEntity}"/>.</returns>
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null);

        /// <summary>
        /// The GetAsync.
        /// </summary>
        /// <param name="predicate">The predicate<see cref="Expression{Func{TEntity, bool}}"/>.</param>
        /// <returns>The <see cref="Task{TEntity}"/>.</returns>
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// The GetByIdAsync.
        /// </summary>
        /// <param name="id">The id<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{TEntity}"/>.</returns>
        Task<TEntity> GetByIdAsync(string id);

        /// <summary>
        /// The InsertAsync.
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/>.</param>
        /// <returns>The <see cref="Task{TEntity}"/>.</returns>
        Task<TEntity> InsertAsync(TEntity entity);

        /// <summary>
        /// The InsertRangeAsync.
        /// </summary>
        /// <param name="entities">The entities<see cref="IEnumerable{TEntity}"/>.</param>
        /// <returns>The <see cref="Task{bool}"/>.</returns>
        Task<bool> InsertRangeAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// The UpdateAsync.
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/>.</param>
        /// <returns>The <see cref="Task{TEntity}"/>.</returns>
        Task<TEntity> UpdateAsync(TEntity entity);

        /// <summary>
        /// The UpdateAsync.
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/>.</param>
        /// <param name="predicate">The predicate<see cref="Expression{Func{TEntity, bool}}"/>.</param>
        /// <returns>The <see cref="Task{TEntity}"/>.</returns>
        Task<TEntity> UpdateAsync(TEntity entity, Expression<Func<TEntity, bool>> predicate);

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
        Task<TEntity> DeleteAsync(string id);

        /// <summary>
        /// The DeleteAsync.
        /// </summary>
        /// <param name="filter">The filter<see cref="Expression{Func{TEntity, bool}}"/>.</param>
        /// <returns>The <see cref="Task{TEntity}"/>.</returns>
        Task<TEntity> DeleteAsync(Expression<Func<TEntity, bool>> filter);
    }
}
