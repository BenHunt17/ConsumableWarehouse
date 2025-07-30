namespace ConsumableWarehouse.Domain.Dtos.Request.Wishlist
{
    public class WishlistProductInput
    {
        public FreeTextProductInput? FreeTextProduct { get; set; }

        public Guid? AffiliateProductExternalId { get; set; }

        public string Comment { get; set; }

        public int Priority { get; set; }
    }
}
