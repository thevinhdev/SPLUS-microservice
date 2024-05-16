using SPLUS.Customer.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SPLUS.Customer.Domain.Interfaces
{
    public interface IFloorAsyncRepository : IAsyncGenericRepository<Floor, int>
    {
        Task<Floor> FindByFloorIdAsync(int floorId, CancellationToken cancellationToken);
        Task<Floor> GetDataByCondition(string condition);
        Task<List<Floor>> GetListDataByCondition(string condition);
    }
}
