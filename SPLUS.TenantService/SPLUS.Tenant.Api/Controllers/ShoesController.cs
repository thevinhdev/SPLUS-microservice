using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SPLUS.Tenant.Application.Shoes;

namespace SPLUS.Tenant.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ShoesController : ControllerBase
    {
        private readonly IShoeService _service;

        public ShoesController(IShoeService service)
        {
            _service = service;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var shoeDetail = await _service.GetByIdAsync(id);
            return Ok(shoeDetail);
        }
    }
}
