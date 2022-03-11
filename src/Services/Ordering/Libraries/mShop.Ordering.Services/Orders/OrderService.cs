using Microsoft.EntityFrameworkCore;
using mShop.Ordering.Core.Domain.Orders;
using mShop.Ordering.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mShop.Ordering.Services.Orders
{
    /// <summary>
    /// Defines the <see cref="OrderService" />.
    /// </summary>
    public class OrderService : IOrderService
    {
        /// <summary>
        /// Defines the _orderRepository.
        /// </summary>
        private readonly IRepository<Order> _orderRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderService"/> class.
        /// </summary>
        /// <param name="orderRepository">The orderRepository<see cref="IRepository{Order}"/>.</param>
        public OrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// The GetCustomerOrders.
        /// </summary>
        /// <param name="username">The username<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{List{Order}}"/>.</returns>
        public async Task<List<Order>> GetCustomerOrders(string username)
        {
            return await _orderRepository.Table.Where(x => x.UserName == username).ToListAsync();
        }

        /// <summary>
        /// The GetOrderByIdAsync.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{Order}"/>.</returns>
        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _orderRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// The UpdateOrderAsync.
        /// </summary>
        /// <param name="order">The order<see cref="Order"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task UpdateOrderAsync(Order order)
        {
            await _orderRepository.UpdateAsync(order);
        }

        /// <summary>
        /// The InsertOrderAsync.
        /// </summary>
        /// <param name="order">The order<see cref="Order"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task InsertOrderAsync(Order order)
        {
            await _orderRepository.InsertAsync(order);
        }

        /// <summary>
        /// The DeleteOrder.
        /// </summary>
        /// <param name="order">The order<see cref="Order"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task DeleteOrderAsync(Order order)
        {
            await _orderRepository.DeleteAsync(order);
        }
    }
}
