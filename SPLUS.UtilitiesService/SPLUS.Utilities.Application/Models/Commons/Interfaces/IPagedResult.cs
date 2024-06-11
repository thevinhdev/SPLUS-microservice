using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPLUS.Utilities.Application.Models.Commons.Interfaces
{
    public interface IPagedResult<TDataResult>
    {
        List<TDataResult> Results { get; set; }
        int CurrentPage { get; set; }
        int PageCount { get; set; }
        int PageSize { get; set; }
        int RowCount { get; set; }
    }

    public interface IPagedResultItem<TDataResult>
    {
        TDataResult Results { get; set; }
        int CurrentPage { get; set; }
        int PageCount { get; set; }
        int PageSize { get; set; }
        int RowCount { get; set; }
    }
}
