using MediatR;
using System.Collections.Generic;

namespace mShop.Ordering.Application.Features.Orders.Queries.GetOrderList
{
    /// <summary>
    /// Defines the <see cref="GetOrderListQuery" />.
    /// </summary>
    public class GetOrderListQuery : IRequest<List<OrderModel>>
    {
        /// <summary>
        /// Gets or sets the Username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetOrderListQuery"/> class.
        /// </summary>
        /// <param name="username">The username<see cref="string"/>.</param>
        public GetOrderListQuery(string username)
        {
            Username = username;
        }
    }
}
