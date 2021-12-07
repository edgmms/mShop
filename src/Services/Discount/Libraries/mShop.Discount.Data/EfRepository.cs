using Microsoft.EntityFrameworkCore;
using mShop.Discount.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mShop.Discount.Data
{
    /// <summary>
    /// Defines the <see cref="EfRepository{TEntity}" />.
    /// </summary>
    /// <typeparam name="TEntity">.</typeparam>
    public partial class EfRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// Defines the _discountDbProvider.
        /// </summary>
        private readonly IDiscountDbProvider _discountDbProvider;

        /// <summary>
        /// Defines the _entities.
        /// </summary>
        private DbSet<TEntity> _entities;

        /// <summary>
        /// Initializes a new instance of the <see cref="EfRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="discountDbProvider">The discountDbProvider<see cref="IDiscountDbProvider"/>.</param>
        public EfRepository(IDiscountDbProvider discountDbProvider)
        {
            _discountDbProvider = discountDbProvider;
            _entities = _discountDbProvider.DbContext.Set<TEntity>();
        }

        /// <summary>
        /// Gets the Table.
        /// </summary>
        public IQueryable<TEntity> Table => _entities.AsQueryable();

        public TEntity GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException("id");

            return _entities.FirstOrDefault(x => x.Id == id);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException("id");

            return await _entities.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Insert(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            _entities.Add(entity);
            _discountDbProvider.DbContext.SaveChanges();
        }

        public async Task InsertAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            await _entities.AddAsync(entity);
            await _discountDbProvider.DbContext.SaveChangesAsync();
        }

        public void InsertRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            _entities.AddRange(entities);
            _discountDbProvider.DbContext.SaveChanges();
        }

        public async Task InsertRangeAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            await _entities.AddRangeAsync(entities);
            await _discountDbProvider.DbContext.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            _entities.Update(entity);
            _discountDbProvider.DbContext.SaveChanges();
        }
        public async Task UpdateAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            _entities.Update(entity);
            await _discountDbProvider.DbContext.SaveChangesAsync();
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            _entities.Remove(entity);
            _discountDbProvider.DbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException("id");

            var entity = this.GetById(id);
            this.Delete(entity);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            _entities.Remove(entity);
            await _discountDbProvider.DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException("id");

            var entity = await this.GetByIdAsync(id);
            await this.DeleteAsync(entity);
        }
    }
}
