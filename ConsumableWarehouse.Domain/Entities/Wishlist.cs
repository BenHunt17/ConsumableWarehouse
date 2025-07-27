namespace ConsumableWarehouse.Domain.Entities
{
    public class Wishlist
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<WishlistProduct> Products { get; set; }
    }
}
