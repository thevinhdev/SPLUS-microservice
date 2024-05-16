using System.Collections.Generic;

namespace SPLUS.Customer.Domain.Interfaces
{
    public interface IResult
    {
        bool Successded { get; set; }
        string[] Errors { get; set; }
        IResult Success();
        IResult Failure(List<string> errors);
    }
}
