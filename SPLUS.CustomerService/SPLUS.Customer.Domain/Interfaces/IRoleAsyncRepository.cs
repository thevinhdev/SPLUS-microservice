using SPLUS.Customer.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SPLUS.Customer.Domain.Interfaces
{
    public interface IRoleAsyncRepository : IAsyncGenericRepository<Role, int>
    {
        Task<Role> FindByCodeAsync(string code, int roleId, CancellationToken cancellationToken);
    }
}
