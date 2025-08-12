using ConsumableWarehouse.Domain.Dtos.Form;
using ConsumableWarehouse.Domain.Entities;

namespace ConsumableWarehouse.Domain.Interfaces.Services
{
    public interface IPartnerService
    {
        IEnumerable<Partner> FindAllPartners(); //TODO - use dto

        Partner RegisterPartner(RegisterPartnerInput input);

        void DeletePartner(int id);
    }
}
