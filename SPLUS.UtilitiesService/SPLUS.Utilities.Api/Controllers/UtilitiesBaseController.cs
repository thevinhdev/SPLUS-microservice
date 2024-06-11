using Abp.Extensions;
using Abp.Runtime.Validation;
using Abp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SPLUS.Shared.Commons.Constants;
using SPLUS.Shared.ViewModels;
using SPLUS.Utilities.Application.Models.Commons;
using System.Linq.Dynamic.Core.Exceptions;

namespace SPLUS.Utilities.Api.Controllers
{
    public class UtilitiesBaseController : ControllerBase
    {
        private readonly ILogger _logger;
        public UtilitiesBaseController()
        {

        }
        //public UtilitiesBaseController(ILogger logger)
        //{
        //    _logger = logger;
        //}

        protected ActionResult Res(ResApi res)
        {
            return Content(res?.ToJson(), "application/json");
        }

        protected ActionResult Res(DefaultResponse res)
        {
            return Content(res?.ToJson(), "application/json");
        }

        protected Output<T> Res<T>(T data, int? metadata = 0, string msg = ApiConstants.MessageResource.ACCTION_SUCCESS, int code = ApiConstants.StatusCode.Success200)
        {
            return new Output<T>
            {
                Data = data,
                Meta = new Meta
                {
                    Error_code = code,
                    Error_message = msg
                },
                Metadata = metadata
            };
        }

        protected async Task<IActionResult> MakeAjaxResponse<T>(Task<T> input)
        {
            try
            {
                T result = await input;
                return Ok(new AjaxResponse(result));
            }
            catch (Exception ex)
            {
                return Ok(CatchException(ex));
            }
        }

        protected IActionResult MakeAjaxResponse<T>(T input)
        {
            try
            {
                T result = input;
                return Ok(new AjaxResponse(result));
            }
            catch (Exception ex)
            {
                return Ok(CatchException(ex));
            }
        }

        protected AjaxResponse CatchException(Exception exception)
        {
            //if (exception is ParseException)
            //{
            //    var ex = exception as ParseException;
            //    var errorInfo = new ErrorInfo()
            //    {
            //        Code = 0,
            //        Details = ex!.Message,
            //    };
            //    return new AjaxResponse(errorInfo);
            //}
            //else if (exception is AbpValidationException)
            //{
            //    var ex = exception as AbpValidationException;
            //    var code = ex.Code;
            //    var message = ex.Message;
            //    xử lý khi truyền nhầm code vào mess
            //    if (!string.IsNullOrWhiteSpace(ex.Message) && ex.Message.Length < 10)
            //    {
            //        if (EnumMethod.HeThong.MaLoi.ListId.Contains(ex.Message))
            //        {
            //            code = ex.Message;
            //            message = "";
            //        }
            //    }

            //    var errorInfo = new ErrorInfo()
            //    {
            //        Code = code,
            //        ValidationErrors = ex.ValidationErrors?.Select(p => new ValidationErrorInfo(p.ErrorMessage, p?.MemberNames?.Select(m => m.ToCamelCase()).ToArray())).ToArray(),
            //        Details = !string.IsNullOrWhiteSpace(message) ? message : ex.ValidationErrors?.Select(p => $"{p.ErrorMessage}").ListToString(Environment.NewLine) ?? null,
            //    };
            //    return new AjaxResponse(errorInfo);
            //}

            //_logger.LogError(exception, exception.Message);
            var mess =
#if DEBUG
            exception.Message;
#else
       "Đã có lỗi xảy ra.";
#endif
            return new AjaxResponse(new ErrorInfo()
            {
                Code = 0,//EnumMethod.HeThong.MaLoi.LoiKhongXacDinh,
                Details = mess,
            });

        }
    }

    public class Output
    {
        [JsonProperty("meta")]
        public Meta Meta { get; set; }

        [JsonProperty("metadata")]
        public int? Metadata { get; set; }
    }

    public class Output<T> : Output
    {
        [JsonProperty("data")]
        public T Data { get; set; }
    }
}
