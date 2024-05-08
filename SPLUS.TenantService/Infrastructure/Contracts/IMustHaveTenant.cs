using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPLUS.Tenant.Infrastructure.Contracts
{
    public interface IMustHaveTenant
    {
        public string TenantId { get; set; }
    }
}
