using AutoMapper;
using mShop.Basket.Api.Models.ShoppingCart;
using mShop.Basket.Core.Domain;
using mShop.Core.Infrastructure.Mapper;

namespace mShop.Basket.Api.Infrastructure.Mapper.Profiles.ShoppingCart
{
    /// <summary>
    /// Defines the <see cref="ShoppingCartItemProfileConfiguration" />.
    /// </summary>
    public class ShoppingCartItemProfileConfiguration : Profile, IOrderedMapperProfile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingCartItemProfileConfiguration"/> class.
        /// </summary>
        public ShoppingCartItemProfileConfiguration()
        {
            this.InitShoppingCartItemProfiles();
        }

        /// <summary>
        /// Gets the Order.
        /// </summary>
        public int Order => 1;

        /// <summary>
        /// The InitShoppingCartItemProfiles.
        /// </summary>
        protected virtual void InitShoppingCartItemProfiles()
        {
            CreateMap<AddShoppingCartItemModel, ShoppingCartItem>();
            CreateMap<ShoppingCartItem, AddShoppingCartItemModel>()
            .ForMember(p => p.ShoppingCartType, opt => opt.Ignore());

            CreateMap<UpdateShoppingCartItemModel, ShoppingCartItem>();
            CreateMap<ShoppingCartItem, UpdateShoppingCartItemModel>()
                .ForMember(p => p.ShoppingCartType, opt => opt.Ignore());
        }
    }
}
