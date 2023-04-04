using System;
using System.Collections.Generic;
using System.Globalization;
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

        public static string RemoveDiacriticalMarks(this string accented)
        {
            var tempBytes = System.Text.Encoding.GetEncoding("ISO-8859-8").GetBytes(accented);
            var asciiStr = System.Text.Encoding.UTF8.GetString(tempBytes);
            return asciiStr;
        }

        public static string RemoveDiacriticalMarks2(this string initialString)
        {
            var normal = initialString.Normalize(NormalizationForm.FormD);

            var withoutDiacritics = normal.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark);

            var final = new string(withoutDiacritics.ToArray());
            return final;
        }
    }
}
