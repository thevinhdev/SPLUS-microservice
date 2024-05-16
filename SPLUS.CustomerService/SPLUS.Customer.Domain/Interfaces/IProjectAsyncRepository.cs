using SPLUS.Customer.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SPLUS.Customer.Domain.Interfaces
{
    public interface IProjectAsyncRepository : IAsyncGenericRepository<Project, int>
    {
        Task<Project> FindByProjectIdAsync(int? projectId, CancellationToken cancellationToken);
        Task<Project> GetDataByCondition(string condition);
        Task<List<Project>> GetListDataByCondition(string condition);
    }
}
