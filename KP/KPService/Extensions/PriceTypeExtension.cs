using KPService.Enum;
using KPService.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KPService.Extensions
{
    public static class PriceTypeExtension
    {
        public static PriceType GetPriceType(this string url)
        {
            var regex = new Regex("priceText=(.*)&search");
            var match = regex.Match(url);
            if (match.Success)
            {
                return ConvertEnum<PriceType>.ToConvert(match.Groups[1].Value);
            }
            else
            {
                return PriceType.Cena;
            }
        }
    }
}
