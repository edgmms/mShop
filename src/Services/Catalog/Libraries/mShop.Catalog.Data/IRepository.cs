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
    /// <typeparam name="string">.</typeparam>
    public partial interface IRepository<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// The GetById.
        /// </summary>
        /// <param name="id">The id<see cref="string"/>.</param>
        /// <returns>The <see cref="TEntity"/>.</returns>
        TEntity GetById(string id);

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
        void Insert(TEntity entity);

        /// <summary>
        /// The InsertAsync.
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task InsertAsync(TEntity entity);

        /// <summary>
        /// The InsertRange.
        /// </summary>
        /// <param name="entities">The entities<see cref="IEnumerable{TEntity}"/>.</param>
        void InsertRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// The InsertRangeAsync.
        /// </summary>
        /// <param name="entities">The entities<see cref="IEnumerable{TEntity}"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task InsertRangeAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// The Update.
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/>.</param>
        void Update(TEntity entity);

        /// <summary>
        /// The Update.
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/>.</param>
        /// <param name="predicate">The predicate<see cref="Expression{Func{TEntity, bool}}"/>.</param>
        void Update(TEntity entity, Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// The UpdateAsync.
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task UpdateAsync(TEntity entity);

        /// <summary>
        /// The UpdateAsync.
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/>.</param>
        /// <param name="predicate">The predicate<see cref="Expression{Func{TEntity, bool}}"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task UpdateAsync(TEntity entity, Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/>.</param>
        void Delete(TEntity entity);

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="id">The id<see cref="string"/>.</param>
        void Delete(string id);

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="filter">The filter<see cref="Expression{Func{TEntity, bool}}"/>.</param>
        void Delete(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// The DeleteAsync.
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task DeleteAsync(TEntity entity);

        /// <summary>
        /// The DeleteAsync.
        /// </summary>
        /// <param name="id">The id<see cref="string"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task DeleteAsync(string id);
       
        /// <summary>
        /// The DeleteAsync.
        /// </summary>
        /// <param name="filter">The filter<see cref="Expression{Func{TEntity, bool}}"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task DeleteAsync(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// Gets the Table.
        /// </summary>
        IQueryable<TEntity> Table { get; }
    }
}
