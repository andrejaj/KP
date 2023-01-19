using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPService.Extensions
{
    public static class FormatExtension
    {
        /// <summary>
        /// removes missing tag or replaces unrecongized chars
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string CleanContent(this string input)
        {
            return input.Replace("&nbsp;", "&#160;").Replace("<br>", "");
        }
    }
}
