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
    /// Defines the <see cref="MongoRepository{TEntity}" />.
    /// </summary>
    /// <typeparam name="TEntity">.</typeparam>
    public partial class MongoRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// Defines the _collection.
        /// </summary>
        private readonly IMongoCollection<TEntity> _collection;

        /// <summary>
        /// Defines the _mongoDbSettings.
        /// </summary>
        private readonly CatalogDbSettings _mongoDbSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="mongoDbSettings">The mongoDbSettings<see cref="CatalogDbSettings"/>.</param>
        public MongoRepository(CatalogDbSettings mongoDbSettings)
        {
            _mongoDbSettings = mongoDbSettings;

            var client = new MongoClient(this._mongoDbSettings.ConnectionString);
            var db = client.GetDatabase(this._mongoDbSettings.Database);
            this._collection = db.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        /// <summary>
        /// The GetByIdAsync.
        /// </summary>
        /// <param name="id">The id<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{TEntity}"/>.</returns>
        public virtual Task<TEntity> GetByIdAsync(string id)
        {
            return _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// The GetById.
        /// </summary>
        /// <param name="id">The id<see cref="string"/>.</param>
        /// <returns>The <see cref="TEntity"/>.</returns>
        public TEntity GetById(string id)
        {
            return _collection.Find(x => x.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// The InsertAsync.
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public virtual async Task InsertAsync(TEntity entity)
        {
            var options = new InsertOneOptions { BypassDocumentValidation = false };
            await _collection.InsertOneAsync(entity, options);
        }

        /// <summary>
        /// The Insert.
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/>.</param>
        public void Insert(TEntity entity)
        {
            var options = new InsertOneOptions { BypassDocumentValidation = false };
            _collection.InsertOne(entity, options);
        }

        /// <summary>
        /// The InsertRangeAsync.
        /// </summary>
        /// <param name="entities">The entities<see cref="IEnumerable{TEntity}"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public virtual async Task InsertRangeAsync(IEnumerable<TEntity> entities)
        {
            var options = new BulkWriteOptions { IsOrdered = false, BypassDocumentValidation = false };
            var result = (await _collection.BulkWriteAsync((IEnumerable<WriteModel<TEntity>>)entities, options)).IsAcknowledged;
        }

        /// <summary>
        /// The InsertRange.
        /// </summary>
        /// <param name="entities">The entities<see cref="IEnumerable{TEntity}"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public void InsertRange(IEnumerable<TEntity> entities)
        {
            var options = new BulkWriteOptions { IsOrdered = false, BypassDocumentValidation = false };
            var result = (_collection.BulkWrite((IEnumerable<WriteModel<TEntity>>)entities, options)).IsAcknowledged;
        }

        /// <summary>
        /// The UpdateAsync.
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public virtual async Task UpdateAsync(TEntity entity)
        {
            await _collection.FindOneAndReplaceAsync(x => x.Id == entity.Id, entity);
        }

        /// <summary>
        /// The Update.
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/>.</param>
        public void Update(TEntity entity)
        {
            _collection.FindOneAndReplace(x => x.Id == entity.Id, entity);
        }

        /// <summary>
        /// The UpdateAsync.
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/>.</param>
        /// <param name="predicate">The predicate<see cref="Expression{Func{TEntity, bool}}"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public virtual async Task UpdateAsync(TEntity entity, Expression<Func<TEntity, bool>> predicate)
        {
            await _collection.FindOneAndReplaceAsync(predicate, entity);
        }

        /// <summary>
        /// The Update.
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/>.</param>
        /// <param name="predicate">The predicate<see cref="Expression{Func{TEntity, bool}}"/>.</param>
        public void Update(TEntity entity, Expression<Func<TEntity, bool>> predicate)
        {
            _collection.FindOneAndReplaceAsync(predicate, entity);
        }

        /// <summary>
        /// The DeleteAsync.
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public virtual async Task DeleteAsync(TEntity entity)
        {
            await _collection.FindOneAndDeleteAsync(x => x.Id == entity.Id);
        }

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/>.</param>
        public void Delete(TEntity entity)
        {
            _collection.FindOneAndDelete(x => x.Id == entity.Id);
        }

        /// <summary>
        /// The DeleteAsync.
        /// </summary>
        /// <param name="id">The id<see cref="string"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public virtual async Task DeleteAsync(string id)
        {
            await _collection.FindOneAndDeleteAsync(x => x.Id == id);
        }

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="id">The id<see cref="string"/>.</param>
        public void Delete(string id)
        {
            _collection.FindOneAndDelete(x => x.Id == id);
        }

        /// <summary>
        /// The DeleteAsync.
        /// </summary>
        /// <param name="filter">The filter<see cref="Expression{Func{TEntity, bool}}"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public virtual async Task DeleteAsync(Expression<Func<TEntity, bool>> filter)
        {
            await _collection.FindOneAndDeleteAsync(filter);
        }

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="filter">The filter<see cref="Expression{Func{TEntity, bool}}"/>.</param>
        public void Delete(Expression<Func<TEntity, bool>> filter)
        {
            _collection.FindOneAndDelete(filter);
        }

        /// <summary>
        /// Gets the Table.
        /// </summary>
        public IQueryable<TEntity> Table
        {
            get { return _collection.AsQueryable(); }
        }
    }
}
