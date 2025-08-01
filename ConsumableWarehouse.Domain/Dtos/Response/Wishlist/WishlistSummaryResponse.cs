using ConsumableWarehouse.Domain.Entities;

namespace ConsumableWarehouse.Domain.Dtos.Response.Wishlist
{
    public class WishlistSummaryResponse
    {
        public Guid ExternalId { get; set; }

        public string Name { get; set; }
    }
}
