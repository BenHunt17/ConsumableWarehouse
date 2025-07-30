using ConsumableWarehouse.Domain.Dtos.Request.Wishlist;
using ConsumableWarehouse.Domain.Dtos.Response.Wishlist;

namespace ConsumableWarehouse.Domain.Interfaces.Services
{
    public interface IWishlistService
    {
        WishlistResponse GetUserWishlist(Guid externalId);

        IEnumerable<WishlistSummaryResponse> GetWishlists();

        WishlistResponse CreateWishlist(WishlistInput input);

        WishlistResponse UpdateWishlist(Guid externalId, WishListSummaryInput input);

        WishlistResponse AddProduct(Guid externalId, WishlistProductInput input);

        WishlistResponse RemoveProduct(Guid externalId, Guid externalWishlistProductId);

        void DeleteWishlist(Guid externalId);
    }
}
