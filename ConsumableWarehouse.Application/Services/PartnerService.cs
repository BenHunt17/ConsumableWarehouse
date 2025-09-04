using ConsumableWarehouse.Domain.Dtos.Form.PartnerInputs;
using ConsumableWarehouse.Domain.Entities;
using ConsumableWarehouse.Domain.Interfaces.Services;
using ConsumableWarehouse.Domain.Mappers;
using ConsumableWarehouse.Domain.Validators.Partner;
using FluentValidation;
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

        public Partner GetPartner(int id)
        {
            return TryGetPartnerById(id);
        }

        public IEnumerable<Partner> FindAllPartners()
        {
            var partners = _dataContext.Partners
                .Include(x => x.AffiliateProducts);

            return partners;
        }

        public Partner RegisterPartner(RegisterPartnerInput input)
        {
            new RegisterPartnerInputValidator().ValidateAndThrow(input);

            var partner = input.ToDomainObject();

            _dataContext.Partners.Add(partner);

            _dataContext.Commit();

            return partner;
        }

        public Partner UpdatePartner(int id, UpdatePartnerInput input)
        {
            new UpdatePartnerInputValidator().ValidateAndThrow(input);

            var partner = TryGetPartnerById(id);

            partner.TradingName = input.TradingName;
            partner.ContactEmailAddress = input.ContactEmailAddress;
            partner.ContactPhoneNumber = input.ContactPhoneNumber;

            _dataContext.Commit();

            return partner;
        }

        public void DeletePartner(int id)
        {
            var partner = TryGetPartnerById(id);

            _dataContext.Partners.Remove(partner);

            _dataContext.Commit();
        }

        private Partner TryGetPartnerById(int id)
        {
            var partner = _dataContext.Partners
                .FirstOrDefault(x => x.Id == id);

            if (partner == null)
            {
                throw new KeyNotFoundException($"Partner with Id {id} not found");
            }
        
            return partner;
        }
    }
}
