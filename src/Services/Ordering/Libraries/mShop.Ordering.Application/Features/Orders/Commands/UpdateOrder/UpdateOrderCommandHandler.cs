using MediatR;
using mShop.Ordering.Application.Infrastructure.Mapper.Extensions;
using mShop.Ordering.Services.Orders;
using System.Threading;
using System.Threading.Tasks;

namespace mShop.Ordering.Application.Features.Orders.Commands.UpdateOrder
{
    /// <summary>
    /// Defines the <see cref="UpdateOrderCommandHandler" />.
    /// </summary>
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        /// <summary>
        /// Defines the _orderService.
        /// </summary>
        private readonly IOrderService _orderService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateOrderCommandHandler"/> class.
        /// </summary>
        /// <param name="orderService">The orderService<see cref="IOrderService"/>.</param>
        public UpdateOrderCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// The Handle.
        /// </summary>
        /// <param name="request">The request<see cref="UpdateOrderCommand"/>.</param>
        /// <param name="cancellationToken">The cancellationToken<see cref="CancellationToken"/>.</param>
        /// <returns>The <see cref="Task{Unit}"/>.</returns>
        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderService.GetOrderByIdAsync(request.Id);
            order = request.ToEntity(order);
            await _orderService.UpdateOrderAsync(order);
            return Unit.Value;
        }
    }
}
