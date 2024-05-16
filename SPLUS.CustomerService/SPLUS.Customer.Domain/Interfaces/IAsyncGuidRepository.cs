using SPLUS.Shared.Commons.BaseEntities;
using System;

namespace SPLUS.Customer.Domain.Interfaces
{
    public interface IAsyncGuidRepository<TEntity> : IAsyncGenericRepository<TEntity, Guid>
        where TEntity : BaseEntity<Guid>
    {
    }
}
