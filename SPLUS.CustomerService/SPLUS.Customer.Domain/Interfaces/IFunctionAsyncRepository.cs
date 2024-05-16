using SPLUS.Customer.Domain.Entities;
using SPLUS.Customer.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SPLUS.Customer.Domain.Interfaces
{
    public interface IFunctionAsyncRepository : IAsyncGenericRepository<Function, int>
    {
        Task<IList<Function>> GetListAllFunctionAsync(CancellationToken cancellationToken);
        Task<List<Function>> GetListFunctionByParentIdAsync(int functionId, CancellationToken cancellationToken);
        Task<Function> FindByCodeAsync(string code, int id, CancellationToken cancellationToken);
        Task<IList<ResSmallFunction>> GetListFunctionAsync(List<ResSmallFunction> dt, int functionId, int level, int roleMax, CancellationToken cancellationToken);
    }
}
