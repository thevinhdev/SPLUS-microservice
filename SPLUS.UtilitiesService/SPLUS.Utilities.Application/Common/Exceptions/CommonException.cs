using SPLUS.Shared.Commons.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPLUS.Utilities.Application.Common.Exceptions
{
    public class CommonException : Exception
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public string ErrorCode { get; set; }

        public CommonException()
            : base()
        {
            Message = string.Empty;
            StatusCode = Constants.StatusCodeResApi.Error404;
            ErrorCode = ApiConstants.ErrorCode.ERROR_BADREQUEST;
        }

        public CommonException(string message = "")
            : base(message)
        {
            Message = message;
            StatusCode = Constants.StatusCodeResApi.Error404;
            ErrorCode = ApiConstants.ErrorCode.ERROR_BADREQUEST;
        }

        public CommonException(string message = "", int errorStatus = Constants.StatusCodeResApi.Error404)
            : base(message)
        {
            Message = message;
            StatusCode = errorStatus;
            ErrorCode = ApiConstants.ErrorCode.ERROR_BADREQUEST;
        }

        public CommonException(string message = "", int errorStatus = Constants.StatusCodeResApi.Error404, string errorCode = ApiConstants.ErrorCode.ERROR_BADREQUEST)
            : base(message)
        {
            Message = message;
            StatusCode = errorStatus;
            ErrorCode = errorCode;
        }
    }
}
