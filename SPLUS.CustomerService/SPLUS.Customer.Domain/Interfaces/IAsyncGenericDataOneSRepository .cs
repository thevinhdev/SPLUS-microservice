using SPLUS.Shared.Commons.BaseEntities;
using SPLUS.Shared.ViewModels.DatabaseOneS;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPLUS.Customer.Domain.Interfaces
{
    public interface IAsyncGenericDataOneSRepository<TEntity>
        where TEntity : Temp_Base
    {
        List<TEntity> All();
    }
}
