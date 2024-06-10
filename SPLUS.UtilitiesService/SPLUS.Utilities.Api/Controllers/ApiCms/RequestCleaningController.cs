using Microsoft.AspNetCore.Mvc;
using SPLUS.Utilities.Application.Services;
using SPLUS.Utilities.Domain.Entities;
using SPLUS.Utilities.Domain.Models.Commons.Interfaces;

namespace SPLUS.Utilities.Api.Controllers.ApiCms
{
    public class RequestCleaningController : BaseController
    {
        private readonly IRequestCleaningService _iRequestCleaningService;

        public RequestCleaningController(IRequestCleaningService iRequestCleaningService)
        {
            _iRequestCleaningService = iRequestCleaningService;
        }

        [HttpGet("GetShoeById")]
        public Output<Shoe> GetShoeById()
        {
            var resData = _iRequestCleaningService.GetShoeById(1);
            return Res(resData);
        }
    }
}
