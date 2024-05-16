using SPLUS.Customer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPLUS.Customer.Domain.Interfaces
{
    public interface IPositionAsyncRepository : IAsyncGenericRepository<Position, int>
    {
    }
}
