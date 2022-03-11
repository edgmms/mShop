using AutoMapper;
using mShop.Core.Infrastructure.Mapper;
using mShop.Ordering.Application.Features.Orders.Commands.UpdateOrder;
using mShop.Ordering.Core.Domain.Orders;
using mShop.Ordering.Application.Features.Orders.Queries.GetOrderList;

namespace mShop.Ordering.Application.Infrastructure.Mapper.Profiles.Orders
{
    /// <summary>
    /// Defines the <see cref="OrderProfileConfiguration" />.
    /// </summary>
    public partial class OrderProfileConfiguration : Profile, IOrderedMapperProfile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderProfileConfiguration"/> class.
        /// </summary>
        public OrderProfileConfiguration()
        {
            this.InitOrderProfiles();
        }

        /// <summary>
        /// Gets the Order.
        /// </summary>
        public int Order => 1;

        /// <summary>
        /// The InitProductProfiles.
        /// </summary>
        protected virtual void InitOrderProfiles()
        {
            CreateMap<Order, OrderModel>().ReverseMap();
            CreateMap<Order, UpdateOrderCommand>().ReverseMap();
        }
    }
}
