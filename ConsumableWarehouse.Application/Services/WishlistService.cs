using ConsumableWarehouse.Domain.Dtos.Request.Wishlist;
using ConsumableWarehouse.Domain.Dtos.Response.Wishlist;
using ConsumableWarehouse.Domain.Entities;
using ConsumableWarehouse.Domain.Interfaces;
using ConsumableWarehouse.Domain.Interfaces.Services;
using ConsumableWarehouse.Domain.Mappers;
using ConsumableWarehouse.Domain.Validators.Wishlist;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ConsumableWarehouse.Application.Services
{
    public class WishlistService : IWishlistService
    {
        private readonly IDataContext _dataContext;
        private readonly IUserContext _userContext;

        public WishlistService(IDataContext dataContext, IUserContext userContext)
        {
            _dataContext = dataContext;
            _userContext = userContext;
        }

        public Wishlist GetWishlist(Guid externalId)
        {
            return TryGetUserWishlist(externalId);
        }

        public IEnumerable<Wishlist> GetCurrentUserWishlists()
        {
            return _dataContext.Wishlists
                .Where(x => x.UserProfileId == _userContext.UserProfileId)
                .ToList();
        }

        public Wishlist CreateWishlist(WishlistInput input)
        {
            new WishlistInputValidator().ValidateAndThrow(input);

            var affiliateProductExternalIds = input.Products
                .Select(x => x.AffiliateProductExternalId)
                .ToList();
            var affiliateProducts = _dataContext.AffiliateProducts
                .Where(x => affiliateProductExternalIds.Contains(x.ExternalId))
                .ToDictionary(x => x.ExternalId, x => x);

            var wishlist = input.ToDomainObject(_userContext.UserProfileId, affiliateProducts);

            _dataContext.Wishlists.Add(wishlist);

            _dataContext.Commit();

            return wishlist;
        }

        public Wishlist UpdateWishlist(Guid externalId, WishlistSummaryInput input)
        {
            new WishlistSummaryInputValidator().ValidateAndThrow(input);

            var wishlist = TryGetUserWishlist(externalId);

            if (wishlist.UserProfileId != _userContext.UserProfileId)
            {
                throw new UnauthorizedAccessException("Cannot modify wishlist which you are not the owner of");
            }

            wishlist.Name = input.Name;
            wishlist.IsPrivate = input.IsPrivate;
            wishlist.LastUpdatedAt = DateTime.UtcNow;

            _dataContext.Commit();

            return wishlist;
        }

        public Wishlist AddProduct(Guid externalId, WishlistProductInput input)
        {
            new WishlistProductInputValidator().ValidateAndThrow(input);

            var wishlist = TryGetUserWishlist(externalId);

            if (wishlist.UserProfileId != _userContext.UserProfileId)
            {
                throw new UnauthorizedAccessException("Cannot modify wishlist which you are not the owner of");
            }

            var affiliateProduct = _dataContext.AffiliateProducts
                .FirstOrDefault(x => x.ExternalId == input.AffiliateProductExternalId);

            wishlist.Products.Add(
                input.ToDomainObject(affiliateProduct));

            wishlist.LastUpdatedAt = DateTime.UtcNow;

            _dataContext.Commit();

            return wishlist;
        }

        public Wishlist RemoveProduct(Guid externalId, Guid externalWishlistProductId)
        {
            var wishlist = TryGetUserWishlist(externalId);

            if (wishlist.UserProfileId != _userContext.UserProfileId)
            {
                throw new UnauthorizedAccessException("Cannot modify wishlist which you are not the owner of");
            }

            var wishlistProduct = wishlist.Products
                .FirstOrDefault(x => x.ExternalId == externalWishlistProductId);

            if (wishlistProduct == null)
            {
                throw new KeyNotFoundException("Wishlist product not found");
            }

            wishlist.Products.Remove(wishlistProduct);
            
            wishlist.LastUpdatedAt = DateTime.UtcNow;

            _dataContext.Commit();

            return wishlist;
        }

        public void DeleteWishlist(Guid externalId)
        {
            var wishlist = TryGetUserWishlist(externalId);

            if (wishlist.UserProfileId != _userContext.UserProfileId)
            {
                throw new UnauthorizedAccessException("Cannot delete wishlist which you are not the owner of");
            }

            _dataContext.Wishlists.Remove(wishlist);

            _dataContext.Commit();
        }

        private Wishlist TryGetUserWishlist(Guid externalId)
        {
            var wishlist = _dataContext.Wishlists
                .Include(x => x.Products)
                    .ThenInclude(x => x.AffiliateProduct)
                .Include(x => x.Products)
                    .ThenInclude(x => x.FreeTextProduct)
                .FirstOrDefault(x => x.ExternalId == externalId
                    && (!x.IsPrivate || x.UserProfileId == _userContext.UserProfileId));

            if (wishlist == null)
            {
                throw new KeyNotFoundException("Wishlist not found");
            }

            return wishlist;
        }
    }
}
