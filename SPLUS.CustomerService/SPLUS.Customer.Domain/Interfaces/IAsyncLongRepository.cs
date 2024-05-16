using SPLUS.Shared.Commons.BaseEntities;

namespace SPLUS.Customer.Domain.Interfaces
{
    public interface IAsyncLongRepository<TEntity> : IAsyncGenericRepository<TEntity, long>
        where TEntity : BaseEntity<long>
    {
    }
}
