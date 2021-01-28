using AutoMapper;
using mShop.Catalog.Api.Models.Catalog;
using mShop.Catalog.Core.Domain.Catalog;
using mShop.Core.Infrastructure.Mapper;

namespace mShop.Catalog.Api.Infrastructure.Mapper.Profiles.Catalog
{
    /// <summary>
    /// Defines the <see cref="ProductProfileConfiguration" />.
    /// </summary>
    public class ProductProfileConfiguration : Profile, IOrderedMapperProfile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductProfileConfiguration"/> class.
        /// </summary>
        public ProductProfileConfiguration()
        {
            this.InitProductProfiles();
        }

        /// <summary>
        /// Gets the Order.
        /// </summary>
        public int Order => 1;

        /// <summary>
        /// The InitProductProfiles.
        /// </summary>
        protected virtual void InitProductProfiles()
        {
            CreateMap<ProductModel, Product>()
                .ForMember(p => p.CreatedById, opt => opt.Ignore());

            CreateMap<Product, ProductModel>();
        }
    }
}
