using MongoDB.Driver;
using mShop.Catalog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace mShop.Catalog.Data
{
    /// <summary>
    /// Defines the <see cref="GenericMongoRepository{TEntity}" />.
    /// </summary>
    /// <typeparam name="TEntity">.</typeparam>
    public class GenericMongoRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// Defines the Collection.
        /// </summary>
        private readonly IMongoCollection<TEntity> Collection;

        /// <summary>
        /// Defines the _mongoDbSettings.
        /// </summary>
        private readonly CatalogDbSettings _mongoDbSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericMongoRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="mongoDbSettings">The mongoDbSettings<see cref="CatalogDbSettings"/>.</param>
        public GenericMongoRepository(CatalogDbSettings mongoDbSettings)
        {
            _mongoDbSettings = mongoDbSettings;

            var client = new MongoClient(this._mongoDbSettings.ConnectionString);
            var db = client.GetDatabase(this._mongoDbSettings.Database);
            this.Collection = db.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        /// <summary>
        /// Gets the Table.
        /// </summary>
        public IQueryable<TEntity> Table
        {
            get { return Collection.AsQueryable(); }
        }

        /// <summary>
        /// The Get.
        /// </summary>
        /// <param name="predicate">The predicate<see cref="Expression{Func{TEntity, bool}}"/>.</param>
        /// <returns>The <see cref="IQueryable{TEntity}"/>.</returns>
        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate == null
                ? Collection.AsQueryable()
                : Collection.AsQueryable().Where(predicate);
        }

        /// <summary>
        /// The GetAsync.
        /// </summary>
        /// <param name="predicate">The predicate<see cref="Expression{Func{TEntity, bool}}"/>.</param>
        /// <returns>The <see cref="Task{TEntity}"/>.</returns>
        public virtual Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Collection.Find(predicate).FirstOrDefaultAsync();
        }

        /// <summary>
        /// The GetByIdAsync.
        /// </summary>
        /// <param name="id">The id<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{TEntity}"/>.</returns>
        public virtual Task<TEntity> GetByIdAsync(string id)
        {
            return Collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// The InsertAsync.
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/>.</param>
        /// <returns>The <see cref="Task{TEntity}"/>.</returns>
        public virtual async Task<TEntity> InsertAsync(TEntity entity)
        {
            var options = new InsertOneOptions { BypassDocumentValidation = false };
            await Collection.InsertOneAsync(entity, options);
            return entity;
        }

        /// <summary>
        /// The InsertRangeAsync.
        /// </summary>
        /// <param name="entities">The entities<see cref="IEnumerable{TEntity}"/>.</param>
        /// <returns>The <see cref="Task{bool}"/>.</returns>
        public virtual async Task<bool> InsertRangeAsync(IEnumerable<TEntity> entities)
        {
            var options = new BulkWriteOptions { IsOrdered = false, BypassDocumentValidation = false };
            return (await Collection.BulkWriteAsync((IEnumerable<WriteModel<TEntity>>)entities, options)).IsAcknowledged;
        }

        /// <summary>
        /// The UpdateAsync.
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/>.</param>
        /// <returns>The <see cref="Task{TEntity}"/>.</returns>
        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            return await Collection.FindOneAndReplaceAsync(x => x.Id == entity.Id, entity);
        }

        /// <summary>
        /// The UpdateAsync.
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/>.</param>
        /// <param name="predicate">The predicate<see cref="Expression{Func{TEntity, bool}}"/>.</param>
        /// <returns>The <see cref="Task{TEntity}"/>.</returns>
        public virtual async Task<TEntity> UpdateAsync(TEntity entity, Expression<Func<TEntity, bool>> predicate)
        {
            return await Collection.FindOneAndReplaceAsync(predicate, entity);
        }

        /// <summary>
        /// The DeleteAsync.
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/>.</param>
        /// <returns>The <see cref="Task{TEntity}"/>.</returns>
        public virtual async Task<TEntity> DeleteAsync(TEntity entity)
        {
            return await Collection.FindOneAndDeleteAsync(x => x.Id == entity.Id);
        }

        /// <summary>
        /// The DeleteAsync.
        /// </summary>
        /// <param name="id">The id<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{TEntity}"/>.</returns>
        public virtual async Task<TEntity> DeleteAsync(string id)
        {
            return await Collection.FindOneAndDeleteAsync(x => x.Id == id);
        }

        /// <summary>
        /// The DeleteAsync.
        /// </summary>
        /// <param name="filter">The filter<see cref="Expression{Func{TEntity, bool}}"/>.</param>
        /// <returns>The <see cref="Task{TEntity}"/>.</returns>
        public virtual async Task<TEntity> DeleteAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await Collection.FindOneAndDeleteAsync(filter);
        }
    }
}
