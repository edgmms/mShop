using AutoMapper;
using mShop.Core.Infrastructure.Mapper;
using mShop.Discount.Core.Domain;
using mShop.Discount.Grpc.Protos;

namespace mShop.Discount.Grpc.Infrastructure.Mapper.Profiles.Coupons
{
    /// <summary>
    /// Defines the <see cref="CouponProfileConfiguration" />.
    /// </summary>
    public partial class CouponProfileConfiguration : Profile, IOrderedMapperProfile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CouponProfileConfiguration"/> class.
        /// </summary>
        public CouponProfileConfiguration()
        {
            this.InitCouponProfiles();
        }

        /// <summary>
        /// Gets the Order.
        /// </summary>
        public int Order => 1;

        /// <summary>
        /// The InitCouponProfiles.
        /// </summary>
        protected virtual void InitCouponProfiles()
        {
            CreateMap<Coupon, CouponModel>().ReverseMap();
        }
    }
}
