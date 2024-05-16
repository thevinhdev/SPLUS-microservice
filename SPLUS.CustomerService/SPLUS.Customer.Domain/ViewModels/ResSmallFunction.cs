using System;
using System.Collections.Generic;
using System.Text;

namespace SPLUS.Customer.Domain.ViewModels
{
    public class ResSmallFunction
    {
        public int FunctionId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? Level { get; set; }
        public bool? IsParamRoute { get; set; }
    }
}
