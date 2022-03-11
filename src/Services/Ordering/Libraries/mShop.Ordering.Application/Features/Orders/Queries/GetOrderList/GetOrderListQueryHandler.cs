using AutoMapper;
using MediatR;
using mShop.Ordering.Application.Infrastructure.Mapper.Extensions;
using mShop.Ordering.Services.Orders;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace mShop.Ordering.Application.Features.Orders.Queries.GetOrderList
{
    /// <summary>
    /// Defines the <see cref="GetOrderListQueryHandler" />.
    /// </summary>
    public class GetOrderListQueryHandler : IRequestHandler<GetOrderListQuery, List<OrderModel>>
    {
        /// <summary>
        /// Defines the _orderService.
        /// </summary>
        private readonly IOrderService _orderService;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetOrderListQueryHandler"/> class.
        /// </summary>
        /// <param name="orderService">The orderService<see cref="IOrderService"/>.</param>
        public GetOrderListQueryHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// The Handle.
        /// </summary>
        /// <param name="request">The request<see cref="GetOrderListQuery"/>.</param>
        /// <param name="cancellationToken">The cancellationToken<see cref="CancellationToken"/>.</param>
        /// <returns>The <see cref="Task{List{OrderModel}}"/>.</returns>
        public async Task<List<OrderModel>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderService.GetCustomerOrders(request.Username);
            return orders.Select(x => x.ToModel()).ToList();
        }
    }
}
