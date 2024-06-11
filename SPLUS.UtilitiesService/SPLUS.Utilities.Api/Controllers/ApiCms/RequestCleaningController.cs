using Microsoft.AspNetCore.Mvc;
using SPLUS.Utilities.Application.Services;
using SPLUS.Utilities.Domain.Entities;

namespace SPLUS.Utilities.Api.Controllers.ApiCms
{
    public class RequestCleaningController : UtilitiesBaseController
    {
        private readonly ILogger _logger;
        private readonly IShoeService _iShoeService;

        public RequestCleaningController(IShoeService iShoeService)
        {
            //_logger = logger;
            _iShoeService = iShoeService;
        }

        [HttpGet("GetShoeById")]
        public Output<Shoe> GetShoeById()
        {
            var resData = _iShoeService.GetShoeById(1);
            return Res(resData, 0, "", 0);
        }

        /// <summary>
        /// Xem hóa đơn điện
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

        //[HttpPost]
        //public async Task<IActionResult> DanhSachLichGCS(PagingInput<DanhSachLichGCS_FilterInput> input) => await MakeAjaxResponse(_iCS_LichGCS_Service.DanhSachLichGCS(input));
    }
}
