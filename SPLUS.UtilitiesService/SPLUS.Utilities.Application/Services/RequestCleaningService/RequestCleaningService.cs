using SPLUS.Utilities.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPLUS.Utilities.Application.Services.RequestCleaningService
{
    public class RequestCleaningService : IRequestCleaningService
    {
        public async Task<Shoe> GetShoeById(int shoeId)
        {
            Shoe shoe = new()
            {
                Id = shoeId,
                Brand = "abc",
                Name = "abc"
            };
            return shoe;
        }
    }
}
