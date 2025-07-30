using ConsumableWarehouse.Domain.Dtos.Request.Wishlist;
using FluentValidation;

namespace ConsumableWarehouse.Domain.Validators.Wishlist
{
    public class WishlistSummaryInputValidator : AbstractValidator<WishListSummaryInput>
    {
        public WishlistSummaryInputValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(99)
                .WithMessage("A wishlist name must be provided and be no longer than 99 characters");
        }
    }
}
