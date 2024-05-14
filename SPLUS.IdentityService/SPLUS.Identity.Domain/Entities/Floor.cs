using IOIT.Shared.Commons.BaseEntities;

namespace SPLUS.Identity.Domain.Entities
{
    public class Floor : AbstractEntity
    {
        public int FloorId { get; set; }
        public int? TowerId { get; set; }
        public int? ProjectId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

    }
}
