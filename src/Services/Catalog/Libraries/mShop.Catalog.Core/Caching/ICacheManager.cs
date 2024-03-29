﻿using System;
using System.Threading.Tasks;

namespace mShop.Catalog.Core.Caching
{
    /// <summary>
    /// Represents a manager for caching
    /// </summary>
    public partial interface ICacheManager : IDisposable
    {
        /// <summary>
        /// Get a cached item. If it's not in the cache yet, then load and cache it
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="key">Cache key</param>
        /// <param name="acquire">Function to load item if it's not in the cache yet</param>
        /// <param name="cacheTime">Cache time</param>
        /// <returns>The cached value associated with the specified key</returns>
        T Get<T>(string key, Func<T> acquire, int cacheTime = 60);

        /// <summary>
        /// Get a cached item. If it's not in the cache yet, then load and cache it
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="key">Cache key</param>
        /// <param name="acquire">Function to load item if it's not in the cache yet</param>
        /// <param name="cacheTime">Cache time</param>
        /// <returns>The cached value associated with the specified key</returns>
        Task<T> GetAsync<T>(string key, Func<Task<T>> acquire, int cacheTime = 60);

        /// <summary>
        /// Removes the value with the specified key from the cache
        /// </summary>
        /// <param name="key">Key of cached item</param>
        void Remove(string key);

        /// <summary>
        /// Adds the specified key and object to the cache
        /// </summary>
        /// <param name="key">Key of cached item</param>
        /// <param name="data">Value for caching</param>
        /// <param name="cacheTime">Cache time</param>
        void Set(string key, object data, int cacheTime = 60);

        /// <summary>
        /// Gets a value indicating whether the value associated with the specified key is cached
        /// </summary>
        /// <param name="key">Key of cached item</param>
        /// <returns>True if item already is in cache; otherwise false</returns>
        bool IsSet(string key);

        /// <summary>
        /// Clear all cache data
        /// </summary>
        void Clear();
    }
}
