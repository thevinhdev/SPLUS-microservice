using Microsoft.AspNetCore.Mvc;
using SPLUS.Utilities.Application.Services;
using SPLUS.Utilities.Application.Services.RequestCleaningService;
using SPLUS.Utilities.Domain.Entities;

namespace SPLUS.Utilities.Api.Controllers.ApiCms
{
    [Route("api/v1/Utilities/[controller]/")]
    public class RequestCleaningController : UtilitiesBaseController
    {
        private readonly ILogger _logger;
        private readonly IShoeService _iShoeService;
        private readonly IRequestCleaningService _iRequestCleaningService;

        public RequestCleaningController(IShoeService iShoeService, IRequestCleaningService iRequestCleaningService)
        {
            //_logger = logger;
            _iShoeService = iShoeService;
            _iRequestCleaningService = iRequestCleaningService;
        }

        [HttpGet("GetShoeById")]
        public Output<Shoe> GetShoeById()
        {
            var resData = _iShoeService.GetShoeById(1);
            return Res(resData, 0, "", 0);
        }

        /// <summary>
        /// GetRequestCleaningServiceById
        /// </summary>
        /// <param name="hoadon"></param>
        /// <returns></returns>
        //[HttpGet("XemHoaDon/{hoaDonDienId}")]
        //public async Task<IActionResult> XemHoaDon(long hoaDonDienId)
        //{
        //    try
        //    {
        //        var bytes = await _iXemHoaDonService.XemHoaDonDien(hoaDonDienId);
        //        string fileName = @$"CCISCloud_HoaDonDien_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.pdf";
        //        return File(bytes, "application/octet-stream", fileName);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(CatchException(ex));
        //    }
        //}

        /// <summary>
        /// GetRequestCleaningServiceById
        /// </summary>
        /// <param name="requestCleaningServiceId">Loại hóa đơn id</param>
        /// <returns></returns>
        [HttpGet("GetRequestCleaningServiceById/{requestCleaningServiceId}")]
        public async Task<IActionResult> GetRequestCleaningServiceById(int requestCleaningServiceId) => await MakeAjaxResponse(_iRequestCleaningService.GetRequestCleaningServiceById(requestCleaningServiceId));
    }
}
