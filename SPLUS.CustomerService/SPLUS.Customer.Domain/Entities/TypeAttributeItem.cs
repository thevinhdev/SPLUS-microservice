using SPLUS.Shared.Commons.BaseEntities;

namespace SPLUS.Customer.Domain.Entities
{
    public class TypeAttributeItem : AbstractEntity
    {
        public int TypeAttributeItemId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
