using MongoDB.Driver;
using mShop.Catalog.Core.Domain.Catalog;
using System;
using System.Collections.Generic;

namespace mShop.Catalog.Data.Infrastructure
{
    /// <summary>
    /// Defines the <see cref="CatalogDbSeeder" />.
    /// </summary>
    public class MongoDbInitializer : IDbInitializer
    {
        /// <summary>
        /// Defines the _mongoDbSettings.
        /// </summary>
        private readonly CatalogDbSettings _mongoDbSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoDbInitializer"/> class.
        /// </summary>
        /// <param name="mongoDbSettings">The mongoDbSettings<see cref="CatalogDbSettings"/>.</param>
        public MongoDbInitializer(CatalogDbSettings mongoDbSettings)
        {
            _mongoDbSettings = mongoDbSettings;
        }

        /// <summary>
        /// The SeedData.
        /// </summary>
        public void Initialize()
        {
            try
            {
                var client = new MongoClient(_mongoDbSettings.ConnectionString);

                var database = client.GetDatabase(_mongoDbSettings.Database);

                database.CreateMongoCollection(nameof(Product));
                database.CreateMongoCollection(nameof(Category));
                database.CreateMongoCollection(nameof(ProductCategoryMapping));


                var productsCollection = database.GetCollection<Product>(nameof(Product));
                bool existProducts = productsCollection.Find(p => true).Any();
                if (!existProducts)
                    productsCollection.InsertManyAsync(SeedProducts());

                var categoryCollection = database.GetCollection<Category>(nameof(Category));
                bool existCategories = categoryCollection.Find(p => true).Any();
                if (!existCategories)
                    categoryCollection.InsertManyAsync(SeedCategories());

                var productCategoryCollection = database.GetCollection<ProductCategoryMapping>(nameof(ProductCategoryMapping));
                if (!existCategories && !existProducts)
                    productCategoryCollection.InsertManyAsync(SeedProductCategoryMappings());
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// The SeedProducts.
        /// </summary>
        /// <returns>The <see cref="IEnumerable{Product}"/>.</returns>
        private static IEnumerable<Product> SeedProducts()
        {
            return new List<Product>() {

                new Product
                {
                     Id = "60045ee5f41e850d9359d903",
                     Name = "Gümüş Yüzük",
                     FullDescription = "Gümüş yüzük açıklaması",
                     Price = 39.90M,
                     Active = true,
                     Deleted = false,
                     CreatedOnUtc = DateTime.UtcNow,
                     UpdatedOnUtc = DateTime.UtcNow

                },

                new Product
                {
                     Id="60045edfd72749acbdd27b45",
                     Name = "Altın Yüzük",
                     FullDescription = "Altın yüzük açıklaması",
                     Price = 109.90M,
                     Active = true,
                     Deleted = false,
                     CreatedOnUtc = DateTime.UtcNow,
                     UpdatedOnUtc = DateTime.UtcNow
                },

                new Product
                {
                     Id = "60045ed14733501b66f2607d",
                     Name = "Safir Yüzük",
                     FullDescription = "Safir yüzük açıklaması",
                     Price = 209.90M,
                     Active = true,
                     Deleted = false,
                     CreatedOnUtc = DateTime.UtcNow,
                     UpdatedOnUtc = DateTime.UtcNow
                }
            };
        }

        /// <summary>
        /// The SeedCategories.
        /// </summary>
        /// <returns>The <see cref="IEnumerable{Category}"/>.</returns>
        private static IEnumerable<Category> SeedCategories()
        {
            return new List<Category> {
                new Category {

                     Id = "60045ecceb9142723a47eadb",
                     Name = "Yüzük",
                     Description = "Yüzük Kategorisi",
                     Active = true,
                     Deleted = false,
                     CreatedOnUtc = DateTime.UtcNow,
                     UpdatedOnUtc = DateTime.UtcNow
                }
            };
        }

        /// <summary>
        /// The SeedProductCategoryMappings.
        /// </summary>
        /// <returns>The <see cref="IEnumerable{ProductCategoryMapping}"/>.</returns>
        private static IEnumerable<ProductCategoryMapping> SeedProductCategoryMappings()
        {
            return new List<ProductCategoryMapping> {

                new ProductCategoryMapping {
                     FeaturedProduct = true,
                     ProductId  ="60045ee5f41e850d9359d903",
                     CategoryId ="60045ecceb9142723a47eadb",
                },
                new ProductCategoryMapping {
                     FeaturedProduct = false,
                     ProductId  ="60045edfd72749acbdd27b45",
                     CategoryId ="60045ecceb9142723a47eadb",
                },
                new ProductCategoryMapping {
                     FeaturedProduct = false,
                     ProductId  ="60045ed14733501b66f2607d",
                     CategoryId ="60045ecceb9142723a47eadb",
                }
            };
        }
    }
}
