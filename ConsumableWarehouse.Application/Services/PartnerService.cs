using ConsumableWarehouse.Domain.Dtos.Form;
using ConsumableWarehouse.Domain.Entities;
using ConsumableWarehouse.Domain.Interfaces;
using ConsumableWarehouse.Domain.Interfaces.Services;
using ConsumableWarehouse.Domain.Mappers;
using Microsoft.EntityFrameworkCore;

namespace ConsumableWarehouse.Application.Services
{
    public class PartnerService : IPartnerService
    {
        private readonly IDataContext _dataContext;

        public PartnerService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Partner> FindAllPartners()
        {
            var partners = _dataContext.Partners
                .Include(x => x.AffiliateProducts);

            return partners;
        }

        public Partner RegisterPartner(RegisterPartnerInput input)
        {
            var partner = input.ToDomainObject();

            _dataContext.Partners.Add(partner);

            _dataContext.Commit();

            return partner;
        }

        public void DeletePartner(int id)
        {
            var partner = _dataContext.Partners
                .FirstOrDefault(x => x.Id == id);

            if (partner == null)
            {
                throw new KeyNotFoundException($"Partner with Id {id} not found");
            }

            _dataContext.Partners.Remove(partner);

            _dataContext.Commit();
        }
    }
}
