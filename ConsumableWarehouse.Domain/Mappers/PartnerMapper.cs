using ConsumableWarehouse.Domain.Dtos.Form;
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
                ContactEmailAddress = input.ContactEmailAddress,
                ContactPhoneNumber = input.ContactPhoneNumber,
                AffiliateProducts = Array.Empty<AffiliateProduct>(),
            };
        }
    }
}
