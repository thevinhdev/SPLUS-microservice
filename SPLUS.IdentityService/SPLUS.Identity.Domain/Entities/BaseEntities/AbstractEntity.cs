using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPLUS.Identity.Domain.Entities.BaseEntities
{
    public class AbstractEntity<TId> : BaseEntity<TId>
    {
        public virtual long? CreatedById { get; set; }
        public virtual long? UpdatedById { get; set; }
    }

    public class AbstractEntity : BaseEntity<int>
    {
        public virtual long? CreatedById { get; set; }
        public virtual long? UpdatedById { get; set; }
    }
}
