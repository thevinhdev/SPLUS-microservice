using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPLUS.Utilities.Application.Common.Exceptions
{
    internal class JsonPropertyAttribute : Attribute
    {
        private string v;

        public JsonPropertyAttribute(string v)
        {
            this.v = v;
        }
    }
}
