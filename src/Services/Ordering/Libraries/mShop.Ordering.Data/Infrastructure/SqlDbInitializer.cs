using mShop.Ordering.Core.Domain;
using mShop.Ordering.Core.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace mShop.Ordering.Data.Infrastructure
{
    /// <summary>
    /// Defines the <see cref="CatalogDbSeeder" />.
    /// </summary>
    public partial class SqlDbInitializer : IDbInitializer
    {

        private readonly IOrderingDbProvider _orderingDbProvider;
        private readonly IRepository<Order> _orderRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlDbInitializer"/> class.
        /// </summary>
        /// <param name="orderRepository">The orderRepository<see cref="IRepository{Order}"/>.</param>
        public SqlDbInitializer(IRepository<Order> orderRepository, 
            IOrderingDbProvider orderingDbProvider)
        {
            _orderRepository = orderRepository;
            _orderingDbProvider = orderingDbProvider;
        }

        /// <summary>
        /// The SeedData.
        /// </summary>
        public void Initialize()
        {
            try
            {
                _orderingDbProvider.DbContext.Database.EnsureCreated();

                if (_orderRepository.Table.Count() == 0)
                {
                    _orderRepository.InsertRange(SeedOrders());
                }
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// The SeedProducts.
        /// </summary>
        /// <returns>The <see cref="IEnumerable{Product}"/>.</returns>
        private static IEnumerable<Order> SeedOrders()
        {
            return new List<Order> {
                 new Order
                 {
                      AddressLine = "Some Address",
                      CardName= "None",
                      CardNumber = "None",
                      Country = "None" ,
                      CVV = "None" ,
                      EmailAddress = "None" 
                 }
            };
        }
    }
}
