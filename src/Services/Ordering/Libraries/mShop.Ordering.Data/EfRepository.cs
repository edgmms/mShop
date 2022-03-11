using Microsoft.EntityFrameworkCore;
using mShop.Ordering.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mShop.Ordering.Data
{
    /// <summary>
    /// Defines the <see cref="EfRepository{TEntity}" />.
    /// </summary>
    /// <typeparam name="TEntity">.</typeparam>
    public partial class EfRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// Defines the _orderDbProvider.
        /// </summary>
        private readonly IOrderingDbProvider _orderDbProvider;

        /// <summary>
        /// Defines the _entities.
        /// </summary>
        private DbSet<TEntity> _entities;

        /// <summary>
        /// Initializes a new instance of the <see cref="EfRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="orderDbProvider">The orderDbProvider<see cref="IOrderingDbProvider"/>.</param>
        public EfRepository(IOrderingDbProvider orderDbProvider)
        {
            _orderDbProvider = orderDbProvider;
            _entities = _orderDbProvider.DbContext.Set<TEntity>();
        }

        /// <summary>
        /// Gets the Table.
        /// </summary>
        public IQueryable<TEntity> Table => _entities.AsQueryable();

        /// <summary>
        /// The GetById.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="TEntity"/>.</returns>
        public TEntity GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException("id");

            return _entities.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// The GetByIdAsync.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{TEntity}"/>.</returns>
        public async Task<TEntity> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException("id");

            return await _entities.FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// The Insert.
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/>.</param>
        public void Insert(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            _entities.Add(entity);
            _orderDbProvider.DbContext.SaveChanges();
        }

        /// <summary>
        /// The InsertAsync.
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task InsertAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            await _entities.AddAsync(entity);
            await _orderDbProvider.DbContext.SaveChangesAsync();
        }

        /// <summary>
        /// The InsertRange.
        /// </summary>
        /// <param name="entities">The entities<see cref="IEnumerable{TEntity}"/>.</param>
        public void InsertRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            _entities.AddRange(entities);
            _orderDbProvider.DbContext.SaveChanges();
        }

        /// <summary>
        /// The InsertRangeAsync.
        /// </summary>
        /// <param name="entities">The entities<see cref="IEnumerable{TEntity}"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task InsertRangeAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            await _entities.AddRangeAsync(entities);
            await _orderDbProvider.DbContext.SaveChangesAsync();
        }

        /// <summary>
        /// The Update.
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/>.</param>
        public void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            _entities.Update(entity);
            _orderDbProvider.DbContext.SaveChanges();
        }

        /// <summary>
        /// The UpdateAsync.
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task UpdateAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            _entities.Update(entity);
            await _orderDbProvider.DbContext.SaveChangesAsync();
        }

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/>.</param>
        public void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            _entities.Remove(entity);
            _orderDbProvider.DbContext.SaveChanges();
        }

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        public void Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException("id");

            var entity = this.GetById(id);
            this.Delete(entity);
        }

        /// <summary>
        /// The DeleteAsync.
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task DeleteAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            _entities.Remove(entity);
            await _orderDbProvider.DbContext.SaveChangesAsync();
        }

        /// <summary>
        /// The DeleteAsync.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException("id");

            var entity = await this.GetByIdAsync(id);
            await this.DeleteAsync(entity);
        }
    }
}
