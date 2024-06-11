using SPLUS.Utilities.Application.Models.RequestCleaningService;
using SPLUS.Utilities.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPLUS.Utilities.Application.Services.RequestCleaningService
{
    public interface IRequestCleaningService
    {
        Task<Shoe> GetShoeById(int shoeId);
        Task<RequestCleaningServiceDto> GetRequestCleaningServiceById(int requestCleaningServiceId);
    }
}
