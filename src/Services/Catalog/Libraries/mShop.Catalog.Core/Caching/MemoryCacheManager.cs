using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mShop.Catalog.Core.Caching
{
    public class MemoryCacheManager : ICacheManager
    {
        #region Fields

        // Flag: Has Dispose already been called?
        private bool _disposed;

        private readonly IMemoryCache _memoryCache;

        private static readonly ConcurrentDictionary<string, CancellationTokenSource> _keys = new ConcurrentDictionary<string, CancellationTokenSource>();
        private static CancellationTokenSource _clearToken = new CancellationTokenSource();

        #endregion

        #region Ctor

        public MemoryCacheManager(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        #endregion

        #region Utilities

        /// <summary>
        /// Prepare cache entry options for the passed key
        /// </summary>
        /// <returns>Cache entry options</returns>
        private MemoryCacheEntryOptions PrepareEntryOptions(string key, int cacheTime)
        {
            //set expiration time for the passed cache key
            var options = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(cacheTime)
            };

            //add tokens to clear cache entries
            options.AddExpirationToken(new CancellationChangeToken(_clearToken.Token));

            var tokenSource = _keys.GetOrAdd(key, new CancellationTokenSource());
            options.AddExpirationToken(new CancellationChangeToken(tokenSource.Token));

            return options;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get a cached item. If it's not in the cache yet, then load and cache it
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="key">Cache key</param>
        /// <param name="acquire">Function to load item if it's not in the cache yet</param>
        /// <param name="cacheTime">Cache time</param>
        /// <returns>The cached value associated with the specified key</returns>
        public T Get<T>(string key, Func<T> acquire, int cacheTime = 60)
        {
            if (cacheTime <= 0)
                return acquire();

            var result = _memoryCache.GetOrCreate(key, entry =>
            {
                entry.SetOptions(PrepareEntryOptions(key, cacheTime));

                return acquire();
            });

            //do not cache null value
            if (result == null)
                Remove(key);

            return result;
        }

        /// <summary>
        /// Get a cached item. If it's not in the cache yet, then load and cache it
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="key">Cache key</param>
        /// <param name="acquire">Function to load item if it's not in the cache yet</param>
        /// <param name="cacheTime">Cache time</param>
        /// <returns>The cached value associated with the specified key</returns>
        public async Task<T> GetAsync<T>(string key, Func<Task<T>> acquire, int cacheTime = 60)
        {
            if (cacheTime <= 0)
                return await acquire();

            var result = await _memoryCache.GetOrCreateAsync(key, async entry =>
            {
                entry.SetOptions(PrepareEntryOptions(key, cacheTime));

                return await acquire();
            });

            //do not cache null value
            if (result == null)
                Remove(key);

            return result;
        }

        /// <summary>
        /// Adds the specified key and object to the cache
        /// </summary>
        /// <param name="key">Key of cached item</param>
        /// <param name="data">Value for caching</param>
        /// <param name="cacheTime">Cache time</param>
        public void Set(string key, object data, int cacheTime = 60)
        {
            if (string.IsNullOrEmpty(key) || data == null)
                return;

            _memoryCache.Set(key, data, PrepareEntryOptions(key, cacheTime));
        }

        /// <summary>
        /// Gets a value indicating whether the value associated with the specified key is cached
        /// </summary>
        /// <param name="key">Key of cached item</param>
        /// <returns>True if item already is in cache; otherwise false</returns>
        public bool IsSet(string key)
        {
            return _memoryCache.TryGetValue(key, out _);
        }

        /// <summary>
        /// Removes the value with the specified key from the cache
        /// </summary>
        /// <param name="key">Key of cached item</param>
        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        /// <summary>
        /// Clear all cache data
        /// </summary>
        public void Clear()
        {
            _clearToken.Cancel();
            _clearToken.Dispose();

            _clearToken = new CancellationTokenSource();

            foreach (var key in _keys.Keys.ToList())
            {
                _keys.TryRemove(key, out var tokenSource);
                tokenSource?.Dispose();
            }
        }

        /// <summary>
        /// Dispose cache manager
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _memoryCache.Dispose();
            }

            _disposed = true;
        }

        #endregion

    }
}








