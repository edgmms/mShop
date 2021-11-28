using mShop.Basket.Api.Models;
using mShop.Basket.Core;
using mShop.Core.Infrastructure.Mapper;
using mShop.EventBus.Events;
using System;
using System.Threading.Tasks;

namespace mShop.Basket.Api.Infrastructure.Mapper.Extensions
{
    public static class AutoMapperExtensions
    {
        #region Utilities

        /// <summary>
        /// Execute a mapping from the source object to a new destination object. The source type is inferred from the source object
        /// </summary>
        /// <typeparam name="TDestination">Destination object type</typeparam>
        /// <param name="source">Source object to map from</param>
        /// <returns>Mapped destination object</returns>
        private static TDestination Map<TDestination>(this object source)
        {
            //use AutoMapper for mapping objects
            return AutoMapperConfiguration.Mapper.Map<TDestination>(source);
        }

        /// <summary>
        /// Execute a mapping from the source object to the existing destination object
        /// </summary>
        /// <typeparam name="TSource">Source object type</typeparam>
        /// <typeparam name="TDestination">Destination object type</typeparam>
        /// <param name="source">Source object to map from</param>
        /// <param name="destination">Destination object to map into</param>
        /// <returns>Mapped destination object, same instance as the passed destination object</returns>
        private static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            //use AutoMapper for mapping objects
            return AutoMapperConfiguration.Mapper.Map(source, destination);
        }

        #endregion

        #region Model-Entity mapping

        /// <summary>
        /// Execute a mapping from the entity to a new model
        /// </summary>
        /// <typeparam name="TModel">Model type</typeparam>
        /// <param name="entity">Entity to map from</param>
        /// <returns>Mapped model</returns>
        public static TModel EntityToModel<TModel>(this BaseEntity entity) where TModel : BaseEntityModel
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return entity.Map<TModel>();
        }

        /// <summary>
        /// Execute a mapping from the entity to a new model
        /// </summary>
        /// <typeparam name="TModel">Model type</typeparam>
        /// <param name="entity">Entity to map from</param>
        /// <returns>Mapped model</returns>
        public static TModel EntityToModel<TModel>(this Task<BaseEntity> entity) where TModel : BaseEntityModel
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return entity.Result.Map<TModel>();
        }

        /// <summary>
        /// Execute a mapping from the entity to the existing model
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <typeparam name="TModel">Model type</typeparam>
        /// <param name="entity">Entity to map from</param>
        /// <param name="model">Model to map into</param>
        /// <returns>Mapped model</returns>
        public static TModel EntityToModel<TEntity, TModel>(this TEntity entity, TModel model)
            where TEntity : BaseEntity where TModel : BaseEntityModel
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (model == null)
                throw new ArgumentNullException(nameof(model));

            return entity.MapTo(model);
        }

        /// <summary>
        /// Execute a mapping from the entity to the existing model
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <typeparam name="TModel">Model type</typeparam>
        /// <param name="entity">Entity to map from</param>
        /// <param name="model">Model to map into</param>
        /// <returns>Mapped model</returns>
        public static TModel EntityToModel<TEntity, TModel>(this Task<TEntity> entity, TModel model)
            where TEntity : BaseEntity where TModel : BaseEntityModel
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (model == null)
                throw new ArgumentNullException(nameof(model));

            return entity.Result.MapTo(model);
        }

        /// <summary>
        /// Execute a mapping from the model to a new entity
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <param name="model">Model to map from</param>
        /// <returns>Mapped entity</returns>
        public static TEntity ModelToEntity<TEntity>(this BaseEntityModel model) where TEntity : BaseEntity
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            return model.Map<TEntity>();
        }

        /// <summary>
        /// Execute a mapping from the model to the existing entity
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <typeparam name="TModel">Model type</typeparam>
        /// <param name="model">Model to map from</param>
        /// <param name="entity">Entity to map into</param>
        /// <returns>Mapped entity</returns>
        public static TEntity ModelToEntity<TEntity, TModel>(this TModel model, TEntity entity)
            where TEntity : BaseEntity where TModel : BaseEntityModel
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return model.MapTo(entity);
        }

        #endregion


        #region Model-Event mapping

        /// <summary>
        /// Execute a mapping from the _event to a new model
        /// </summary>
        /// <typeparam name="TModel">Model type</typeparam>
        /// <param name="_event">Event to map from</param>
        /// <returns>Mapped model</returns>
        public static TModel EventToModel<TModel>(this BaseEvent _event) where TModel : BaseEntityModel
        {
            if (_event == null)
                throw new ArgumentNullException(nameof(_event));

            return _event.Map<TModel>();
        }

        /// <summary>
        /// Execute a mapping from the _event to a new model
        /// </summary>
        /// <typeparam name="TModel">Model type</typeparam>
        /// <param name="_event">Event to map from</param>
        /// <returns>Mapped model</returns>
        public static TModel EventToModel<TModel>(this Task<BaseEvent> _event) where TModel : BaseEntityModel
        {
            if (_event == null)
                throw new ArgumentNullException(nameof(_event));

            return _event.Result.Map<TModel>();
        }

        /// <summary>
        /// Execute a mapping from the _event to the existing model
        /// </summary>
        /// <typeparam name="TEvent">Event type</typeparam>
        /// <typeparam name="TModel">Model type</typeparam>
        /// <param name="_event">Event to map from</param>
        /// <param name="model">Model to map into</param>
        /// <returns>Mapped model</returns>
        public static TModel EventToModel<TEvent, TModel>(this TEvent _event, TModel model)
            where TEvent : BaseEvent where TModel : BaseEntityModel
        {
            if (_event == null)
                throw new ArgumentNullException(nameof(_event));

            if (model == null)
                throw new ArgumentNullException(nameof(model));

            return _event.MapTo(model);
        }

        /// <summary>
        /// Execute a mapping from the _event to the existing model
        /// </summary>
        /// <typeparam name="TEvent">Event type</typeparam>
        /// <typeparam name="TModel">Model type</typeparam>
        /// <param name="_event">Event to map from</param>
        /// <param name="model">Model to map into</param>
        /// <returns>Mapped model</returns>
        public static TModel EventToModel<TEvent, TModel>(this Task<TEvent> _event, TModel model)
            where TEvent : BaseEvent where TModel : BaseEntityModel
        {
            if (_event == null)
                throw new ArgumentNullException(nameof(_event));

            if (model == null)
                throw new ArgumentNullException(nameof(model));

            return _event.Result.MapTo(model);
        }

        /// <summary>
        /// Execute a mapping from the model to a new _event
        /// </summary>
        /// <typeparam name="TEvent">Event type</typeparam>
        /// <param name="model">Model to map from</param>
        /// <returns>Mapped _event</returns>
        public static TEvent ModelToEvent<TEvent>(this BaseEntityModel model) where TEvent : BaseEvent
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            return model.Map<TEvent>();
        }

        /// <summary>
        /// Execute a mapping from the model to the existing _event
        /// </summary>
        /// <typeparam name="TEvent">Event type</typeparam>
        /// <typeparam name="TModel">Model type</typeparam>
        /// <param name="model">Model to map from</param>
        /// <param name="_event">Event to map into</param>
        /// <returns>Mapped _event</returns>
        public static TEvent ModelToEvent<TEvent, TModel>(this TModel model, TEvent _event)
            where TEvent : BaseEvent where TModel : BaseEntityModel
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            if (_event == null)
                throw new ArgumentNullException(nameof(_event));

            return model.MapTo(_event);
        }

        #endregion



    }
}
