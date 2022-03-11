using MediatR;
using mShop.Ordering.Application.Infrastructure.Mapper.Extensions;
using mShop.Ordering.Services.Orders;
using System.Threading;
using System.Threading.Tasks;

namespace mShop.Ordering.Application.Features.Orders.Commands.InsertOrder
{
    /// <summary>
    /// Defines the <see cref="InsertOrderCommandHandler" />.
    /// </summary>
    public class InsertOrderCommandHandler : IRequestHandler<InsertOrderCommand, int>
    {
        /// <summary>
        /// Defines the _orderService.
        /// </summary>
        private readonly IOrderService _orderService;

        /// <summary>
        /// Initializes a new instance of the <see cref="InsertOrderCommandHandler"/> class.
        /// </summary>
        /// <param name="orderService">The orderService<see cref="IOrderService"/>.</param>
        public InsertOrderCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// The Handle.
        /// </summary>
        /// <param name="request">The request<see cref="InsertOrderCommand"/>.</param>
        /// <param name="cancellationToken">The cancellationToken<see cref="CancellationToken"/>.</param>
        /// <returns>The <see cref="Task{int}"/>.</returns>
        public async Task<int> Handle(InsertOrderCommand request, CancellationToken cancellationToken)
        {
            var order = request.ToEntity();
            await _orderService.InsertOrderAsync(order);
            return order.Id;
        }
    }
}
