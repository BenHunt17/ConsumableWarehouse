namespace ConsumableWarehouse.Domain.Dtos.Response.AffiliateProduct
{
    public class AffiliateProductSummaryResponse
    {
        public Guid ExternalId { get; set; }

        public string Name { get; set; }

        public string? Category { get; set; }
    }
}
