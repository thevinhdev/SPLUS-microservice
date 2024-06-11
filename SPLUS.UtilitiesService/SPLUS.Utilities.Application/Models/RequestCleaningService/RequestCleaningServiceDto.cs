using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPLUS.Utilities.Application.Models.RequestCleaningService
{
    public class RequestCleaningServiceDto
    {
        public int Id { get; set; }
        public string ProjectCode { get; set; } = null!;
        public string TowerCode { get; set; } = null!;
        public string ApartmentCode { get; set; } = null!;
        public string ApartmentName { get; set; } = null!;
        public int ResidentId { get; set; }
        public string ResidentName { get; set; } = null!;
        public string UserRequestName { get; set; } = null!;
        public string? UserRequestPhone { get; set; }
        public int ProcessStatus { get; set; }
        public string Note { get; set; } = null!;
        public int CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedById { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
