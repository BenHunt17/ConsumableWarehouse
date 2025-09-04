using ConsumableWarehouse.Domain.Dtos.Form.PartnerInputs;
using ConsumableWarehouse.Domain.Entities;

namespace ConsumableWarehouse.Domain.Mappers
{
    public static class PartnerMapper
    {
        public static Partner ToDomainObject(this RegisterPartnerInput input)
        {
            return new Partner
            {
                CompanyName = input.CompanyName,
                TradingName = input.TradingName,
                VatNumber = input.VatNumber,
                ContactEmailAddress = input.ContactEmailAddress,
                ContactPhoneNumber = input.ContactPhoneNumber,
                AffiliateProducts = Array.Empty<AffiliateProduct>(),
            };
        }
    }
}
