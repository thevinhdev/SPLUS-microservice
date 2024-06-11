using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPLUS.Utilities.Application.Common.Extensions
{
    public static class DateTimeExtension
    {
        public static DateTime? StringToDateTime(
            string dateTime,
            string format)
        {
            DateTime resultDate;

            var isValid = !DateTime.TryParseExact(dateTime, format, (IFormatProvider)CultureInfo.InvariantCulture, DateTimeStyles.None, out resultDate);

            if (isValid == true)
            {
                return resultDate;
            }

            return null;
        }
    }
}
