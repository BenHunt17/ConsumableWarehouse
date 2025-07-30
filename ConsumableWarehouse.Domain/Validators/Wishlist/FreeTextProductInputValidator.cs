using ConsumableWarehouse.Domain.Dtos.Request.Wishlist;
using FluentValidation;

namespace ConsumableWarehouse.Domain.Validators.Wishlist
{
    public class FreeTextProductInputValidator : AbstractValidator<FreeTextProductInput>
    {
        public FreeTextProductInputValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(99)
                .WithMessage("A free text product name must be provided and be no longer than 99 characters");
        }
    }
}
