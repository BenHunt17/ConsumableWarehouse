namespace ConsumableWarehouse.Domain.Entities
{
    public class FreeTextProduct
    {
        public int Id { get; set; }

        public int Name { get; set; }

        public int WishlistProductId { get; set; }
        public WishlistProduct WishlistProduct { get; set; }
    }
}
