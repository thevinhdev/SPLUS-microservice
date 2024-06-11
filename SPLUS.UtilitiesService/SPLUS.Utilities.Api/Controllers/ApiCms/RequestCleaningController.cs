using Microsoft.AspNetCore.Mvc;
using SPLUS.Utilities.Application.Services;
using SPLUS.Utilities.Domain.Entities;

namespace SPLUS.Utilities.Api.Controllers.ApiCms
{
    public class RequestCleaningController : BaseController
    {
        private readonly IShoeService _iShoeService;

        public RequestCleaningController(IShoeService iShoeService)
        {
            _iShoeService = iShoeService;
        }

        [HttpGet("GetShoeById")]
        public Output<Shoe> GetShoeById()
        {
            var resData = _iShoeService.GetShoeById(1);
            return Res(resData, 0, "", 0);
        }
    }
}
