using ConsumableWarehouse.Domain.Dtos.Request.Wishlist;
using ConsumableWarehouse.Domain.Entities;

namespace ConsumableWarehouse.Domain.Interfaces.Services
{
    public interface IWishlistService
    {
        Wishlist GetWishlist(Guid externalId);

        IEnumerable<Wishlist> GetCurrentUserWishlists();

        Wishlist CreateWishlist(WishlistInput input);

        Wishlist UpdateWishlist(Guid externalId, WishlistSummaryInput input);

        Wishlist AddProduct(Guid externalId, WishlistProductInput input);

        Wishlist RemoveProduct(Guid externalId, Guid externalWishlistProductId);

        void DeleteWishlist(Guid externalId);
    }
}
