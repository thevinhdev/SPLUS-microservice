using SPLUS.Customer.Domain.Entities;
using SPLUS.Customer.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SPLUS.Customer.Domain.Interfaces
{
    public interface IUtilitiesRepository : IAsyncGenericRepository<Utilities, int>
    {
        Task<Utilities> getUtilitiesByNameOrCode(string name, string code, CancellationToken cancellationToken);
        Task<Utilities> checkExistUtilitiesByNameOrCode(string name, string code, int id, CancellationToken cancellationToken);
        Task<List<Utilities>> getUtilitiesByProjectId(int projectId, CancellationToken cancellationToken);
    }
}
