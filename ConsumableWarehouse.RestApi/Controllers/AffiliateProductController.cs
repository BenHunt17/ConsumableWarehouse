using ConsumableWarehouse.Domain.Dtos.Request.AffiliateProduct;
using ConsumableWarehouse.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ConsumableWarehouse.RestApi.Controllers
{
    [ApiController]
    [Route("api/private/affiliateproduct/")]
    public class AffiliateProductController : ControllerBase
    {
        private readonly IAffiliateProductService _affiliateProductService;

        public AffiliateProductController(IAffiliateProductService affiliateProductService)
        {
            _affiliateProductService = affiliateProductService;
        }

        /// <summary>
        /// Imports affiliate products for a partner
        /// </summary>
        [HttpPost("import/{partnerId}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> ImportAffiliateProducts(int partnerId, [FromBody] IEnumerable<AffiliateProductImportInput> input)
        {
            await _affiliateProductService.ImportAffiliateProducts(partnerId, input);
            return NoContent();
        }
    }
}
