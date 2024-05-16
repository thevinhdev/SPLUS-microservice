﻿using SPLUS.Customer.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SPLUS.Customer.Domain.Interfaces
{
    public interface IApartmentAsyncRepository : IAsyncGenericRepository<Apartment, int>
    {
        Task<Apartment> FindByApartmentIdAsync(int? apartmentId, CancellationToken cancellationToken);
        Task<Apartment> GetDataByCondition(string condition);
        Task<List<Apartment>> GetListDataByCondition(string condition);
    }
}
