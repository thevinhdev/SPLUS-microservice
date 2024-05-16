using SPLUS.Shared.Commons.BaseEntities;

namespace SPLUS.Customer.Domain.Interfaces
{
    public interface IAsyncRepository<TEntity> : IAsyncGenericRepository<TEntity, int>
       where TEntity : BaseEntity<int>
    {
    }
}
