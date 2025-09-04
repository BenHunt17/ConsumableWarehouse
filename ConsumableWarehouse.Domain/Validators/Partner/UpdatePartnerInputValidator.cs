using FluentValidation;
using ConsumableWarehouse.Domain.Dtos.Form.PartnerInputs;

namespace ConsumableWarehouse.Domain.Validators.Partner
{
    public class UpdatePartnerInputValidator : AbstractValidator<UpdatePartnerInput>
    {
        public UpdatePartnerInputValidator()
        {
            RuleFor(x => x.TradingName)
                .MaximumLength(99)
                .WithMessage("A trading name must be no longer than 99 characters");

            RuleFor(x => x.ContactEmailAddress)
                .NotEmpty()
                .MaximumLength(99)
                .WithMessage("An email must be provided and be no longer than 99 characters");

            RuleFor(x => x.ContactPhoneNumber)
                .NotEmpty()
                .MaximumLength(20)
                .WithMessage("A phone number must be provided and be no longer than 99 characters");
        }
    }
}
