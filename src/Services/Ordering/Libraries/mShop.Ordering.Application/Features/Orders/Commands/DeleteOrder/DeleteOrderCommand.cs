using MediatR;

namespace mShop.Ordering.Application.Features.Orders.Commands.DeleteOrder
{
    /// <summary>
    /// Defines the <see cref="DeleteOrderCommand" />.
    /// </summary>
    public class DeleteOrderCommand : IRequest
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public int Id { get; set; }
    }
}
