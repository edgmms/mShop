using FluentValidation;

namespace mShop.Ordering.Application.Features.Orders.Commands.InsertOrder
{
    /// <summary>
    /// Defines the <see cref="InsertOrderCommandValidator" />.
    /// </summary>
    public class InsertOrderCommandValidator : AbstractValidator<InsertOrderCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InsertOrderCommandValidator"/> class.
        /// </summary>
        public InsertOrderCommandValidator()
        {
            RuleFor(p => p.UserName)
               .NotEmpty().WithMessage("{UserName} is required.")
               .NotNull()
               .MaximumLength(50).WithMessage("{UserName} must not exceed 50 characters.");

            RuleFor(p => p.EmailAddress)
               .NotEmpty().WithMessage("{EmailAddress} is required.");

            RuleFor(p => p.TotalPrice)
                .NotEmpty().WithMessage("{TotalPrice} is required.")
                .GreaterThan(0).WithMessage("{TotalPrice} should be greater than zero.");
        }
    }
}
