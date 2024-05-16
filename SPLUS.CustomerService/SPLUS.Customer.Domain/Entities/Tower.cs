using SPLUS.Shared.Commons.BaseEntities;

namespace SPLUS.Customer.Domain.Entities
{
    public class Tower : AbstractEntity
    {
        public int TowerId { get; set; }
        public int? ProjectId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

    }
}
