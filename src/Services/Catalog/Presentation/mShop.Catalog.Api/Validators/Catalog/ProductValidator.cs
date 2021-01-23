using FluentValidation;
using mShop.Catalog.Api.Models.Catalog;
using mShop.Catalog.Api.Validators.Messages;

namespace mShop.Catalog.Api.Validators.Catalog
{
    public class ProductValidator : BaseFluentValidator<ProductModel>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(ProductValidationMessage.NameNotEmpty);
        }
    }
}
