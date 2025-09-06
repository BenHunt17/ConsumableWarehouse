namespace ConsumableWarehouse.Domain.Dtos.Request.AffiliateProduct
{
    public class AffiliateProductSearchInput
    {
        public string? SearchTerm { get; set; }

        public Guid? CurrentId { get; set; }

        public int? Limit { get; set; }
    }
}
