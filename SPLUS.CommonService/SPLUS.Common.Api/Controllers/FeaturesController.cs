using Microsoft.AspNetCore.Mvc;
using SPLUS.Common.Application.Services;

namespace SPLUS.Common.Api.Controllers
{
    [Route("api/v1/[controller]/")]
    [ApiController]
    public class FeaturesController : Controller
    {
        private readonly IFeatureService _iFeatureService;

        public FeaturesController(IFeatureService iFeatureService)
        {
            _iFeatureService = iFeatureService;
        }

        [HttpGet("GetFeatureById/{featureId}")]
        public async Task<IActionResult> GetFeatureById(int featureId)
        {
            var fetature = await _iFeatureService.GetFeatureById(featureId);
            return Ok(fetature);
        }
    }
}
