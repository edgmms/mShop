using RedLockNet.SERedis;
using RedLockNet.SERedis.Configuration;
using StackExchange.Redis;
using System;
using System.Linq;
using System.Net;

namespace mShop.Basket.Data
{
    /// <summary>
    /// Represents Redis context implementation.
    /// </summary>
    public class BasketDbProvider : IBasketDbProvider
    {
        /// <summary>
        /// Defines the _disposed.
        /// </summary>
        private bool _disposed = false;

        /// <summary>
        /// Defines the _basketDbSettings.
        /// </summary>
        private readonly BasketDbSettings _basketDbSettings;

        /// <summary>
        /// Defines the _lock.
        /// </summary>
        private readonly object _lock = new object();

        /// <summary>
        /// Defines the _connectionString.
        /// </summary>
        private readonly Lazy<string> _connectionString;

        /// <summary>
        /// Defines the _connection.
        /// </summary>
        private volatile ConnectionMultiplexer _connection;

        /// <summary>
        /// Defines the _redisLockFactory.
        /// </summary>
        private volatile RedLockFactory _redisLockFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="BasketDbProvider"/> class.
        /// </summary>
        /// <param name="basketDbSettings">The basketDbSettings<see cref="BasketDbSettings"/>.</param>
        public BasketDbProvider(BasketDbSettings basketDbSettings)
        {
            _basketDbSettings = basketDbSettings;
            _connectionString = new Lazy<string>(GetConnectionString);
            _redisLockFactory = CreateRedisLockFactory();
        }

        /// <summary>
        /// Get connection string to Redis cache from configuration.
        /// </summary>
        /// <returns>.</returns>
        protected string GetConnectionString()
        {
            return _basketDbSettings.ConnectionString;
        }

        /// <summary>
        /// Get connection to Redis servers.
        /// </summary>
        /// <returns>.</returns>
        protected ConnectionMultiplexer GetConnection()
        {
            if (_connection != null && _connection.IsConnected) return _connection;

            lock (_lock)
            {
                if (_connection != null && _connection.IsConnected) return _connection;

                //Connection disconnected. Disposing connection...
                _connection?.Dispose();

                //Creating new instance of Redis Connection
                _connection = ConnectionMultiplexer.Connect(_connectionString.Value);
            }

            return _connection;
        }

        /// <summary>
        /// Create instance of RedLock factory.
        /// </summary>
        /// <returns>RedLock factory.</returns>
        protected RedLockFactory CreateRedisLockFactory()
        {
            //get RedLock endpoints
            var configurationOptions = ConfigurationOptions.Parse(_connectionString.Value);
            var redLockEndPoints = GetEndPoints().Select(endPoint => new RedLockEndPoint
            {
                EndPoint = endPoint,
                Password = configurationOptions.Password,
                Ssl = configurationOptions.Ssl,
                RedisDatabase = configurationOptions.DefaultDatabase,
                ConfigCheckSeconds = configurationOptions.ConfigCheckSeconds,
                ConnectionTimeout = configurationOptions.ConnectTimeout,
                SyncTimeout = configurationOptions.SyncTimeout
            }).ToList();

            //create RedLock factory to use RedLock distributed lock algorithm
            return RedLockFactory.Create(redLockEndPoints);
        }

        /// <summary>
        /// Obtain an interactive connection to a database inside Redis.
        /// </summary>
        /// <param name="databaseNumber">The databaseNumber<see cref="int"/>.</param>
        /// <returns>Redis cache database.</returns>
        public IDatabase GetDatabase(int databaseNumber = 0)
        {
            return GetConnection().GetDatabase(databaseNumber == 0 ? _basketDbSettings.DatabaseNumber : databaseNumber);
        }

        /// <summary>
        /// Obtain a configuration API for an individual server.
        /// </summary>
        /// <param name="endPoint">The network endpoint.</param>
        /// <returns>Redis server.</returns>
        public IServer GetServer(EndPoint endPoint)
        {
            return GetConnection().GetServer(endPoint);
        }

        /// <summary>
        /// Gets all endpoints defined on the server.
        /// </summary>
        /// <returns>Array of endpoints.</returns>
        public EndPoint[] GetEndPoints()
        {
            return GetConnection().GetEndPoints();
        }

        /// <summary>
        /// Delete all the keys of the database.
        /// </summary>
        /// <param name="databaseNumber">Database number.</param>
        public void FlushDatabase(int databaseNumber)
        {
            var endPoints = GetEndPoints();

            foreach (var endPoint in endPoints)
            {
                GetServer(endPoint).FlushDatabase(databaseNumber);
            }
        }

        /// <summary>
        /// Release all resources associated with this object.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        /// <summary>
        /// The Dispose.
        /// </summary>
        /// <param name="disposing">The disposing<see cref="bool"/>.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                //dispose ConnectionMultiplexer
                _connection?.Dispose();

                //dispose RedLock factory
                _redisLockFactory?.Dispose();
            }
            _disposed = true;
        }
    }
}
