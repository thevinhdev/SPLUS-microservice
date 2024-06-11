using SPLUS.Utilities.Application.Models.RequestCleaningService;
using SPLUS.Utilities.Domain.Entities;
using SPLUS.Utilities.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPLUS.Utilities.Application.Services.RequestCleaningService
{
    public class RequestCleaningService : IRequestCleaningService
    {
        private readonly ApplicationDbContext _dbContext;
        public RequestCleaningService(ApplicationDbContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task<RequestCleaningServiceDto> GetRequestCleaningServiceById(int requestCleaningServiceId)
        {
            var reqCleaningService = _dbContext.RequestCleaningService.Where(x => x.Id == requestCleaningServiceId).First();
            RequestCleaningServiceDto resRequestCleaningServiceDto = new()
            {
                Id = reqCleaningService.Id,
                ProjectCode = reqCleaningService.ProjectCode,
                TowerCode = reqCleaningService.TowerCode,
                ApartmentCode = reqCleaningService.ApartmentCode,
                ApartmentName = reqCleaningService.ApartmentName,
                ResidentId = reqCleaningService.ResidentId,
                ResidentName = reqCleaningService.ResidentName,
                UserRequestName = reqCleaningService.UserRequestName,
                UserRequestPhone = reqCleaningService.UserRequestPhone,
                ProcessStatus = reqCleaningService.ProcessStatus,
                Note = reqCleaningService.Note,
                CreatedById = reqCleaningService.CreatedById,
                CreatedAt = reqCleaningService.CreatedAt,
                UpdatedById = reqCleaningService.UpdatedById,
                UpdatedAt = reqCleaningService.UpdatedAt,
            };
            return resRequestCleaningServiceDto;
        }

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
