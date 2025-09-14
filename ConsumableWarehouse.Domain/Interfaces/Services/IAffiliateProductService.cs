using ConsumableWarehouse.Domain.Dtos.Request.AffiliateProduct;
using ConsumableWarehouse.Domain.Dtos.Response.AffiliateProduct;
using ConsumableWarehouse.Domain.Entities;

namespace ConsumableWarehouse.Domain.Interfaces.Services
{
    public interface IAffiliateProductService
    {
        Task ImportAffiliateProducts(int partnerId, IEnumerable<AffiliateProductImportInput> input);

        IEnumerable<AffiliateProduct> Search(AffiliateProductSearchInput input);
    }
}
