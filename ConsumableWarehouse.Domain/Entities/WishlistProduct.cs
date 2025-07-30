namespace ConsumableWarehouse.Domain.Entities
{
    public class WishlistProduct
    {
        public int Id { get; set; }

        public Guid ExternalId { get; set; }

        public string? Comment { get; set; }

        public int Priority { get; set; }

        public FreeTextProduct? FreeTextProduct { get; set; }

        public int? AffiliateProductId { get; set; }
        public AffiliateProduct? AffiliateProduct { get; set; }

        public Wishlist Wishlist { get; set; }
    }
}
