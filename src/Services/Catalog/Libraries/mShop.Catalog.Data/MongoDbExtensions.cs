using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;

namespace mShop.Catalog.Data
{
    /// <summary>
    /// Defines the <see cref="MongoDbExtensions" />.
    /// </summary>
    public static class MongoDbExtensions
    {
        /// <summary>
        /// The MongoCollectionExists.
        /// </summary>
        /// <param name="database">The database<see cref="IMongoDatabase"/>.</param>
        /// <param name="collectionName">The collectionName<see cref="string"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public static bool MongoCollectionExists(this IMongoDatabase database, string collectionName)
        {
            var filter = new BsonDocument("name", collectionName);

            //filter by collection name
            var collections = database.ListCollections(new ListCollectionsOptions { Filter = filter });

            //check for existence
            return collections.Any();
        }

        /// <summary>
        /// The CreateMongoCollection.
        /// </summary>
        /// <param name="database">The database<see cref="IMongoDatabase"/>.</param>
        /// <param name="collectionName">The collectionName<see cref="string"/>.</param>
        public static void CreateMongoCollection(this IMongoDatabase database, string collectionName)
        {
            if (!MongoCollectionExists(database, collectionName))
                database.CreateCollection(collectionName);
        }
    }
}
