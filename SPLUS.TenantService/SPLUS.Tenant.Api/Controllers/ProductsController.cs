using Microsoft.AspNetCore.Mvc;
using SPLUS.Tenant.Application.Products;

namespace SPLUS.Tenant.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }
        //[HttpGet]
        //public async Task<IActionResult> GetAsync(int id)
        //{
        //    var productDetails = await _service.GetByIdAsync(id);
        //    return Ok(productDetails);
        //}

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var productDetails = await _service.GetByIdAsync(id);
            return Ok(productDetails);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateProductRequest request)
        {
            return Ok(await _service.CreateAsync(request.Name, request.Description, request.Rate));
        }
    }
    public class CreateProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Rate { get; set; }
    }
}
