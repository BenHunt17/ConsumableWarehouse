using ConsumableWarehouse.Domain.Dtos.Request.AffiliateProduct;
using FluentValidation;

namespace ConsumableWarehouse.Domain.Validators.AffiliateProduct
{
    public class AffiliateProductImportInputValidator : AbstractValidator<AffiliateProductImportInput>
    {
        public AffiliateProductImportInputValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(99)
                .WithMessage("An affiliate product name must be provided and be no longer than 99 characters");

            RuleFor(x => x.AffiliateLink)
                .MaximumLength(999)
                .WithMessage("An affiliate link must be no longer than 99 characters");
        }
    }
}
