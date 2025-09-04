using ConsumableWarehouse.Domain.Dtos.Request.Wishlist;
using ConsumableWarehouse.Domain.Dtos.Response.Wishlist;
using ConsumableWarehouse.Domain.Interfaces.Services;
using ConsumableWarehouse.Domain.Mappers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ConsumableWarehouse.RestApi.Controllers
{
    [ApiController]
    [Route("api/public/wishlist/")]
    public class WishlistController : ControllerBase
    {
        private readonly IWishlistService _wishlistService;

        public WishlistController(IWishlistService wishlistService)
        {
            _wishlistService = wishlistService;
        }

        /// <summary>
        /// Gets a wishlist by its external Id.
        /// </summary>
        [HttpGet("{externalId}")]
        [ProducesResponseType(typeof(WishlistResponse), (int)HttpStatusCode.OK)]
        public IActionResult Get(Guid externalId)
        {
            var wishlist = _wishlistService.GetWishlist(externalId);
            return Ok(wishlist.ToResponse());
        }

        /// <summary>
        /// Gets all wishlists for the current user
        /// </summary>
        [HttpGet("currentuser")]
        [ProducesResponseType(typeof(IEnumerable<WishlistSummaryResponse>), (int)HttpStatusCode.OK)]
        public IActionResult GetCurrentUserWishlists()
        {
            var wishlists = _wishlistService.GetCurrentUserWishlists();

            var wishlistsReponse = wishlists
                .Select(x => x.ToSummaryResponse())
                .ToList();

            return Ok(wishlistsReponse);
        }

        /// <summary>
        /// Creates a new wishlist.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(WishlistResponse), (int)HttpStatusCode.Created)]
        public IActionResult CreateWishlist([FromBody] WishlistInput input)
        {
            var wishlist = _wishlistService.CreateWishlist(input);
            return Created(wishlist.ExternalId.ToString(), wishlist.ToResponse());
        }

        /// <summary>
        /// Updates the basic infromation of a wishlist.
        /// </summary>
        [HttpPatch("{externalId}")]
        [ProducesResponseType(typeof(WishlistResponse), (int)HttpStatusCode.OK)]
        public IActionResult UpdateWishlist(Guid externalId, [FromBody] WishlistSummaryInput input)
        {
            var wishlist = _wishlistService.UpdateWishlist(externalId, input);
            return Ok(wishlist.ToResponse());
        }

        /// <summary>
        /// Adds a new product to a wishlist.
        /// <remarks>FreeTextProduct and AffiliateProductExternalId are mutually exclusive</remarks>
        /// </summary>
        [HttpPost("{externalId}/addproduct")]
        [ProducesResponseType(typeof(WishlistResponse), (int)HttpStatusCode.OK)]
        public IActionResult AddProduct(Guid externalId, [FromBody] WishlistProductInput input)
        {
            var wishlist = _wishlistService.AddProduct(externalId, input);
            return Ok(wishlist.ToResponse());
        }

        /// <summary>
        /// Removes a product from a wishlist.
        /// </summary>
        [HttpDelete("{externalId}/removeproduct")]
        [ProducesResponseType(typeof(WishlistResponse), (int)HttpStatusCode.OK)]
        public IActionResult RemoveProduct(Guid externalId, [FromBody] Guid productExternalId)
        {
            var wishlist = _wishlistService.RemoveProduct(externalId, productExternalId);
            return Ok(wishlist.ToResponse());
        }

        /// <summary>
        /// Deletes a wishlist along with all of its products
        /// </summary>
        [HttpDelete("{externalId}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult Delete(Guid externalId)
        {
            _wishlistService.DeleteWishlist(externalId);
            return NoContent();
        }
    }
}
