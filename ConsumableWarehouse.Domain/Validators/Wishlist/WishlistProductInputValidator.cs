using ConsumableWarehouse.Domain.Dtos.Request.Wishlist;
using FluentValidation;

namespace ConsumableWarehouse.Domain.Validators.Wishlist
{
    public class WishlistProductInputValidator : AbstractValidator<WishlistProductInput>
    {
        public WishlistProductInputValidator()
        {
            RuleFor(x => x.FreeTextProduct)
                .Null()
                .When(x => x.AffiliateProductExternalId != null)
                .WithMessage("Affiliate product and free text product information is mutually exclusive");

            RuleFor(x => x.AffiliateProductExternalId)
                .Null()
                .When(x => x.FreeTextProduct != null)
                .WithMessage("Affiliate product and free text product information is mutually exclusive");

            RuleFor(x => x)
                .Must(x => x.AffiliateProductExternalId != null || x.FreeTextProduct != null)
                .WithMessage("Either affiliate product or free text product information must be provided");

            RuleFor(x => x.FreeTextProduct!) //I hate using the non-null assertion operator but I couldn't get the warning to go away here and it is checking for null anyway
                .SetValidator(new FreeTextProductInputValidator())
                .When(x => x.FreeTextProduct != null);

            RuleFor(x => x.Comment)
                .MaximumLength(999);

            RuleFor(x => x.Priority)
                .InclusiveBetween(1, 5)
                .WithMessage("Priority number should be between 1 and 5");
        }
    }
}
