using ConsumableWarehouse.Domain.Dtos.Request.Wishlist;
using ConsumableWarehouse.Domain.Dtos.Response.Wishlist;
using ConsumableWarehouse.Domain.Entities;

namespace ConsumableWarehouse.Domain.Mappers
{
    public static class WishlistMapper
    {
        public static Wishlist ToDomainObject(this WishlistInput input, IDictionary<Guid, AffiliateProduct>? affiliateProducts = null)
        {
            var wishlist = new Wishlist
            {
                ExternalId = new Guid(),
                Name = input.Name,
                IsPrivate = input.IsPrivate,
            };

            foreach (var product in input.Products)
            {
                AffiliateProduct? affiliateProduct = null;

                if (product.AffiliateProductExternalId != null)
                {
                    if (!(affiliateProducts != null
                        && affiliateProducts.TryGetValue((Guid)product.AffiliateProductExternalId, out affiliateProduct)))
                    {
                        throw new KeyNotFoundException($"No affiliate product associated with Id {product.AffiliateProductExternalId} was found");
                    }
                }

                wishlist.Products.Add(
                    product.ToDomainObject(affiliateProduct));
            }

            return wishlist;
        }

        public static WishlistResponse ToResponse(this Wishlist wishlist)
        {
            return new WishlistResponse
            {
                Name = wishlist.Name,
                Products = wishlist.Products.Select(x => x.ToResponse())
            };
        }

        public static WishlistSummaryResponse ToSummaryResponse(this Wishlist wishlist)
        {
            return new WishlistSummaryResponse
            {
                Name = wishlist.Name,
            };
        }
    }
}
