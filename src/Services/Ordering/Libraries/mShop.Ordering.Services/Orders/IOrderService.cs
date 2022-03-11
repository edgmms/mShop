using mShop.Ordering.Core.Domain.Orders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mShop.Ordering.Services.Orders
{
    /// <summary>
    /// Defines the <see cref="IOrderService" />.
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// The GetOrderByIdAsync.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{Order}"/>.</returns>
        Task<Order> GetOrderByIdAsync(int id);

        /// <summary>
        /// The GetCustomerOrders.
        /// </summary>
        /// <param name="username">The username<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{List{Order}}"/>.</returns>
        Task<List<Order>> GetCustomerOrders(string username);

        /// <summary>
        /// The UpdateOrderAsync.
        /// </summary>
        /// <param name="order">The order<see cref="Order"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task UpdateOrderAsync(Order order);

        /// <summary>
        /// The InsertOrderAsync.
        /// </summary>
        /// <param name="order">The order<see cref="Order"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task InsertOrderAsync(Order order);

        /// <summary>
        /// The DeleteOrderAsync.
        /// </summary>
        /// <param name="order">The order<see cref="Order"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task DeleteOrderAsync(Order order);
    }
}
