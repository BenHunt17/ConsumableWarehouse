using ConsumableWarehouse.Domain.Dtos.Request.AffiliateProduct;
using ConsumableWarehouse.Domain.Dtos.Response.AffiliateProduct;
using ConsumableWarehouse.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ConsumableWarehouse.RestApi.Controllers
{
    [ApiController]
    [Route("api/public/product/")]
    public class ProductController : ControllerBase
    {
        private readonly IAffiliateProductService _affiliateProductService;

        public ProductController(IAffiliateProductService affiliateProductService)
        {
            _affiliateProductService = affiliateProductService;
        }

        /// <summary>
        /// Searchs for available products across all providers
        /// </summary>
        [HttpPost("search")]
        [ProducesResponseType(typeof(IEnumerable<AffiliateProductSummaryResponse>), (int)HttpStatusCode.OK)]
        public IActionResult Search(int partnerId, [FromBody] AffiliateProductSearchInput input)
        {
            var products = _affiliateProductService.Search(input);
            return Ok(products);
        }
    }
}
