namespace ConsumableWarehouse.Domain.Entities
{
    public class Wishlist
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsPrivate { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime LastUpdatedAt {  get; set; }

        public ICollection<WishlistProduct> Products { get; set; }

        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }
    }
}
