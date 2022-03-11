using MediatR;
using mShop.Ordering.Services.Orders;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace mShop.Ordering.Application.Features.Orders.Commands.DeleteOrder
{
    /// <summary>
    /// Defines the <see cref="DeleteOrderCommandHandler" />.
    /// </summary>
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        /// <summary>
        /// Defines the _orderService.
        /// </summary>
        private readonly IOrderService _orderService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteOrderCommandHandler"/> class.
        /// </summary>
        /// <param name="orderService">The orderService<see cref="IOrderService"/>.</param>
        public DeleteOrderCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// The Handle.
        /// </summary>
        /// <param name="request">The request<see cref="DeleteOrderCommand"/>.</param>
        /// <param name="cancellationToken">The cancellationToken<see cref="CancellationToken"/>.</param>
        /// <returns>The <see cref="Task{Unit}"/>.</returns>
        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderService.GetOrderByIdAsync(request.Id);
            if (order == null)
                throw new ArgumentNullException("id");

            await _orderService.DeleteOrderAsync(order);

            return Unit.Value;
        }
    }
}
