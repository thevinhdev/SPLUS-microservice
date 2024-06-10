using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SPLUS.Shared.Commons.Constants;
using SPLUS.Shared.ViewModels;
using SPLUS.Utilities.Domain.Models.Commons;

namespace SPLUS.Utilities.Api.Controllers
{
    public class BaseController : ControllerBase
    {
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
