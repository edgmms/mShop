using StackExchange.Redis;
using System;
using System.Net;

namespace mShop.Basket.Data
{
    /// <summary>
    /// Represents Redis connection wrapper.
    /// </summary>
    public interface IBasketDbProvider : IDisposable
    {
        /// <summary>
        /// Obtain an interactive connection to a database inside Redis.
        /// </summary>
        /// <param name="databaseNumber">The databaseNumber<see cref="int"/>.</param>
        /// <returns>Redis cache database.</returns>
        IDatabase GetDatabase(int databaseNumber = 0);

        /// <summary>
        /// Obtain a configuration API for an individual server.
        /// </summary>
        /// <param name="endPoint">The network endpoint.</param>
        /// <returns>Redis server.</returns>
        IServer GetServer(EndPoint endPoint);

        /// <summary>
        /// Gets all endpoints defined on the server.
        /// </summary>
        /// <returns>Array of endpoints.</returns>
        EndPoint[] GetEndPoints();

        /// <summary>
        /// Delete all the keys of the database.
        /// </summary>
        /// <param name="databaseNumber">Database number.</param>
        void FlushDatabase(int databaseNumber);
    }
}
