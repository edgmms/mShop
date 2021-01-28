using mShop.Catalog.Core;
using mShop.Catalog.Data;
using mShop.Core.Infrastructure;
using System;
using System.Threading.Tasks;

namespace mShop.Catalog.Services
{
    /// <summary>
    /// Defines the <see cref="ServiceBase{TEntity}" />.
    /// </summary>
    /// <typeparam name="TEntity">.</typeparam>
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// Defines the _repository.
        /// </summary>
        protected readonly IRepository<TEntity> _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBase{TEntity}"/> class.
        /// </summary>
        public ServiceBase()
        {
            _repository = EngineContext.Current.Resolve<IRepository<TEntity>>();
        }

        /// <summary>
        /// The GetByIdAsync.
        /// </summary>
        /// <param name="id">The id<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{TEntity}"/>.</returns>
        public virtual Task<TEntity> GetByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException("id");

            return _repository.GetByIdAsync(id);
        }

        /// <summary>
        /// The Insert.
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public virtual async Task InsertAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            await _repository.InsertAsync(entity);
        }

        /// <summary>
        /// The Update.
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public virtual async Task UpdateAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            await _repository.UpdateAsync(entity);
        }

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public virtual async Task DeleteAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            await _repository.DeleteAsync(entity);
        }

        /// <summary>
        /// The DeleteById.
        /// </summary>
        /// <param name="id">The id<see cref="string"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public virtual async Task DeleteByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException("id");

            await _repository.DeleteAsync(id);
        }
    }
}
