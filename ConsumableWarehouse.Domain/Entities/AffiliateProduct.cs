namespace ConsumableWarehouse.Domain.Entities
{
    public class AffiliateProduct
    {
        public int Id { get; set; }

        public Guid ExternalId { get; set; }

        public string Name { get; set; }

        public string AffiliateLink { get; set; }

        public int PartnerId { get; set; }
        public Partner Partner { get; set; }

        public int? ProductCategoryId { get; set; }
        public ProductCategory? ProductCategory { get; set; }

        public ICollection<WishlistProduct> WishlistProducts { get; set; }
    }
}
