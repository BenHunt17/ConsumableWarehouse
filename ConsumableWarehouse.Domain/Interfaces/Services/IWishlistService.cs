using ConsumableWarehouse.Domain.Dtos.Request.Wishlist;
using ConsumableWarehouse.Domain.Dtos.Response.Wishlist;

namespace ConsumableWarehouse.Domain.Interfaces.Services
{
    public interface IWishlistService
    {
        WishlistResponse GetWishlist(Guid externalId);

        IEnumerable<WishlistSummaryResponse> GetCurrentUserWishlists();

        WishlistResponse CreateWishlist(WishlistInput input);

        WishlistResponse UpdateWishlist(Guid externalId, WishlistSummaryInput input);

        WishlistResponse AddProduct(Guid externalId, WishlistProductInput input);

        WishlistResponse RemoveProduct(Guid externalId, Guid externalWishlistProductId);

        void DeleteWishlist(Guid externalId);
    }
}
