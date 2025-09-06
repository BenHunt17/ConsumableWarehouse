using ConsumableWarehouse.Domain.Dtos.Request.AffiliateProduct;
using ConsumableWarehouse.Domain.Dtos.Response.AffiliateProduct;

namespace ConsumableWarehouse.Domain.Interfaces.Services
{
    public interface IAffiliateProductService
    {
        Task ImportAffiliateProducts(int partnerId, IEnumerable<AffiliateProductImportInput> input);

        IEnumerable<AffiliateProductSummaryResponse> Search(AffiliateProductSearchInput input);
    }
}
