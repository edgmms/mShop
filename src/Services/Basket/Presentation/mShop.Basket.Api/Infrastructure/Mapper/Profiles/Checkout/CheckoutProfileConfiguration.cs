using AutoMapper;
using mShop.Basket.Api.Models.Checkout;
using mShop.Core.Infrastructure.Mapper;
using mShop.EventBus.Events.Basket.Checkout;

namespace mShop.Basket.Api.Infrastructure.Mapper.Profiles.Checkout
{
    /// <summary>
    /// Defines the <see cref="CheckoutProfileConfiguration" />.
    /// </summary>
    public partial class CheckoutProfileConfiguration : Profile, IOrderedMapperProfile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckoutProfileConfiguration"/> class.
        /// </summary>
        public CheckoutProfileConfiguration()
        {
            this.InitCheckoutProfiles();
        }

        /// <summary>
        /// Gets the Order.
        /// </summary>
        public int Order => 1;

        /// <summary>
        /// The InitProductProfiles.
        /// </summary>
        protected virtual void InitCheckoutProfiles()
        {
            CreateMap<CheckoutModel, CheckoutEvent>()
              .ForMember(p => p.RequestId, opt => opt.Ignore());

            CreateMap<CheckoutEvent, CheckoutModel>();
        }
    }
}
