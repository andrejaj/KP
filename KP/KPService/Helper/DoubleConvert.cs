using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPService.Helper
{
    internal static class ConvertDouble
    {
        public static double ToDouble(this string value)
        {
            double result;
            double.TryParse(value, System.Globalization.NumberStyles.Any, CultureInfo.GetCultureInfo("sr-Latn-CS"), out result);
            return result;
        }
    }
}
