using ConsumableWarehouse.Domain.Entities;

namespace ConsumableWarehouse.Domain.Dtos.Response.Wishlist
{
    public class WishlistResponse
    {
        public Guid ExternalId { get; set; }

        public string Name { get; set; }

        public IEnumerable<WishlistProductResponse> Products { get; set; }
    }
}
