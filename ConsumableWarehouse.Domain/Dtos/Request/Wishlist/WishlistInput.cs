namespace ConsumableWarehouse.Domain.Dtos.Request.Wishlist
{
    public class WishlistInput
    {
        public string Name { get; set; }

        public bool IsPrivate { get; set; }

        public IEnumerable<WishlistProductInput> Products { get; set; }
    }
}
