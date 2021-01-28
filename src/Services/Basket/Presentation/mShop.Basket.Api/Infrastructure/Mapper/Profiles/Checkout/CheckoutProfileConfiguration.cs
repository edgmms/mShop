using AutoMapper;
using mShop.Core.Infrastructure.Mapper;

namespace mShop.Basket.Api.Infrastructure.Mapper.Profiles.Checkout
{
    /// <summary>
    /// Defines the <see cref="CheckoutProfileConfiguration" />.
    /// </summary>
    public class CheckoutProfileConfiguration : Profile, IOrderedMapperProfile
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
            
        }
    }
}
