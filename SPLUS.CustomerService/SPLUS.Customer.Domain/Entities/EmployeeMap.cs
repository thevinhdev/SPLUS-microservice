using SPLUS.Shared.Commons.BaseEntities;
using System;

namespace SPLUS.Customer.Domain.Entities
{
    public class EmployeeMap : AbstractEntity
    {
        //public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? TowerId { get; set; }
        //public DateTime? CreatedAt { get; set; }
        //public int? UserId { get; set; }
        //public byte? Status { get; set; }
    }
}
