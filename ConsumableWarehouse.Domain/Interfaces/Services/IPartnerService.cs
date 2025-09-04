using ConsumableWarehouse.Domain.Dtos.Form.PartnerInputs;
using ConsumableWarehouse.Domain.Entities;

namespace ConsumableWarehouse.Domain.Interfaces.Services
{
    public interface IPartnerService
    {
        Partner GetPartner(int id);

        IEnumerable<Partner> FindAllPartners();

        Partner RegisterPartner(RegisterPartnerInput input);

        Partner UpdatePartner(int id, UpdatePartnerInput input);

        void DeletePartner(int id);
    }
}
