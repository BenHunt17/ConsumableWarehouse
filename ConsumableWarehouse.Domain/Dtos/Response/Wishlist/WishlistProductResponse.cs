using ConsumableWarehouse.Domain.Entities;

namespace ConsumableWarehouse.Domain.Dtos.Response.Wishlist
{
    public class WishlistProductResponse
    {
        public Guid ExernalId { get; set; }

        public string Name { get; set; }

        public string? Url { get; set; }

        public string? Comment { get; set; }

        public int Priority { get; set; }
    }
}
