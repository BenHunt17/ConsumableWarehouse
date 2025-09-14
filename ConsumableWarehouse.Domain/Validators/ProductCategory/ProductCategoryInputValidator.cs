using ConsumableWarehouse.Domain.Dtos.Form.PartnerInputs;
using FluentValidation;

namespace ConsumableWarehouse.Domain.Validators.ProductCategory
{
    public class ProductCategoryInputValidator : AbstractValidator<ProductCategoryInput>
    {
        public ProductCategoryInputValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(99)
                .WithMessage("A category name must be provided and be no longer than 99 characters");
        }
    }
}
