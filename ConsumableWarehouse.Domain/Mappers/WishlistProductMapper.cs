using ConsumableWarehouse.Domain.Dtos.Request.Wishlist;
using ConsumableWarehouse.Domain.Dtos.Response.Wishlist;
using ConsumableWarehouse.Domain.Entities;
using System;

namespace ConsumableWarehouse.Domain.Mappers
{
    public static class WishlistProductMapper
    {
        public static WishlistProduct ToDomainObject(this WishlistProductInput input, AffiliateProduct? affiliateProduct = null)
        {
            var wishlistProduct = new WishlistProduct
            {
                ExternalId = Guid.NewGuid(),
                Comment = input.Comment,
                Priority = input.Priority,
            };

            if (affiliateProduct != null)
            {
                wishlistProduct.AffiliateProduct = affiliateProduct;
            }
            else if (input.FreeTextProduct != null)
            {
                wishlistProduct.FreeTextProduct = new FreeTextProduct
                {
                    Name = input.FreeTextProduct?.Name ?? string.Empty,
                };
            }

            return wishlistProduct;
        }

        public static WishlistProductResponse ToResponse(this WishlistProduct wishlistProduct)
        {
            var response = new WishlistProductResponse
            {
                ExernalId = wishlistProduct.ExternalId,
                Comment = wishlistProduct.Comment,
                Priority = wishlistProduct.Priority,
            };

            if (wishlistProduct.AffiliateProduct != null)
            {
                response.Name = wishlistProduct.AffiliateProduct.Name;
                response.Url = wishlistProduct.AffiliateProduct?.AffiliateLink;
            }
            else if (wishlistProduct.FreeTextProduct != null)
            {
                response.Name = wishlistProduct.FreeTextProduct.Name;
            }

            return response;
        }
    }

}
