using ConsumableWarehouse.Domain.Dtos.Request.AffiliateProduct;
using ConsumableWarehouse.Domain.Dtos.Response.AffiliateProduct;
using ConsumableWarehouse.Domain.Entities;

namespace ConsumableWarehouse.Domain.Mappers
{
    public static class AffiliateProductMapper
    {
        public static AffiliateProduct ToDomainObject(this AffiliateProductImportInput input, int partnerId, int? productCategoryId)
        {
            return new AffiliateProduct
            {
                ExternalId = Guid.NewGuid(),
                Name = input.Name,
                AffiliateLink = input.AffiliateLink,
                PartnerId = partnerId,
                ProductCategoryId = productCategoryId
            };
        }

        public static AffiliateProductSummaryResponse ToSummaryResponse(this AffiliateProduct affiliateProduct)
        {
            return new AffiliateProductSummaryResponse
            {
                ExternalId = affiliateProduct.ExternalId,
                Name = affiliateProduct.Name,
                Category = affiliateProduct.ProductCategory?.Name,
            };
        }
    }
}