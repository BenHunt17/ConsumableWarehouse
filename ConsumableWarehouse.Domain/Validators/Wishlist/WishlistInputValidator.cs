using ConsumableWarehouse.Domain.Dtos.Request.Wishlist;
using FluentValidation;

namespace ConsumableWarehouse.Domain.Validators.Wishlist
{
    public class WishlistInputValidator : AbstractValidator<WishlistInput>
    {
        public WishlistInputValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(99)
                .WithMessage("A wishlist name must be provided and be no longer than 99 characters");

            RuleForEach(x => x.Products)
                .SetValidator(new WishlistProductInputValidator());
        }
    }
}
