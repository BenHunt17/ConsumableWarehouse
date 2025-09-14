using ConsumableWarehouse.Domain.Dtos.Request.AffiliateProduct;
using ConsumableWarehouse.Domain.Entities;
using ConsumableWarehouse.Domain.Interfaces.Services;
using ConsumableWarehouse.Domain.Mappers;
using ConsumableWarehouse.Domain.Validators.AffiliateProduct;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ConsumableWarehouse.Application.Services
{
    public class AffiliateProductService : IAffiliateProductService
    {
        private readonly IDataContext _dataContext;

        public AffiliateProductService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task ImportAffiliateProducts(int partnerId, IEnumerable<AffiliateProductImportInput> input)
        {
            var validator = new AffiliateProductImportInputValidator();
            foreach (var item in input)
            {
                validator.ValidateAndThrow(item);
            }

            var partner = _dataContext.Partners.FirstOrDefault(x => x.Id == partnerId);
            if (partner == null)
            {
                throw new KeyNotFoundException("Partner does not exist");
            }

            var affiliateProducts = input
                .Select(x => x.ToDomainObject(partnerId))
                .ToList();

            await _dataContext.AffiliateProducts.AddRangeAsync(affiliateProducts);

            _dataContext.Commit();
        }

        public IEnumerable<AffiliateProduct> Search(AffiliateProductSearchInput input)
        {
            var limit = input.Limit ?? 10;
            if (limit > 99)
            {
                throw new ArgumentOutOfRangeException(nameof(AffiliateProductSearchInput.Limit), "Limit can not be higher than 99");
            }

            var query = _dataContext.AffiliateProducts.AsQueryable();

            if (!string.IsNullOrWhiteSpace(input.SearchTerm))
            {
                query = query.Where(x => EF.Functions.Like(x.Name, "%" + input.SearchTerm + "%"));
            }

            if (input.CurrentId != null)
            {
                var currentProduct = _dataContext.AffiliateProducts
                    .FirstOrDefault(x => x.ExternalId == input.CurrentId);

                if (currentProduct == null)
                {
                    throw new KeyNotFoundException("Id for current product not found");
                }

                query = query.Where(x => x.Id > currentProduct.Id);
            }

            var products = query
                .Take(limit)
                .ToList();

            return products;
        }
    }
}
