using mShop.Core.Infrastructure.Mapper;
using mShop.Ordering.Application.Features.Orders.Commands.InsertOrder;
using mShop.Ordering.Application.Features.Orders.Commands.UpdateOrder;
using mShop.Ordering.Application.Features.Orders.Queries.GetOrderList;
using mShop.Ordering.Core.Domain.Orders;

namespace mShop.Ordering.Application.Infrastructure.Mapper.Extensions
{
    public static class AutoMapperExtensions
    {
        #region Utilities

        public static TDestination MapTo<TSource, TDestination>(this TSource source)
        {
            return AutoMapperConfiguration.Mapper.Map<TSource, TDestination>(source);
        }

        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return AutoMapperConfiguration.Mapper.Map(source, destination);
        }

        #endregion

        #region Order

        public static Order ToEntity(this UpdateOrderCommand model, Order destination)
        {
            return model.MapTo(destination);
        }

        public static OrderModel ToModel(this Order entity)
        {
            return entity.MapTo<Order, OrderModel>();
        }

        public static Order ToEntity(this InsertOrderCommand model)
        {
            return model.MapTo<InsertOrderCommand, Order>();
        }

        #endregion

    }
}
