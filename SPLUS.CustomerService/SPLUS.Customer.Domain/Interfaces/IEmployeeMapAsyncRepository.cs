using SPLUS.Customer.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SPLUS.Customer.Domain.Interfaces
{
    public interface IEmployeeMapAsyncRepository : IAsyncGenericRepository<EmployeeMap, int>
    {
        Task<EmployeeMap> GetEmployeeTowerAsync(int employeeId, int towerId, CancellationToken cancellationToken);
        Task<List<EmployeeMap>> GetByEmployeeIdAsync(int employeeId, CancellationToken cancellationToken);
    }
}
