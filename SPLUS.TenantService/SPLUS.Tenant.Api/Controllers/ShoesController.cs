using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace SPLUS.Tenant.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
