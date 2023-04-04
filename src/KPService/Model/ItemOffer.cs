using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPService.Model
{
    public class ItemOffer
    {
        [JsonProperty("url")]
        public string Url { get; set; }
        
        [JsonProperty("priceCurrency")]
        public string Currency;
        
        [JsonProperty("price")]
        public string Price;
        
        [JsonProperty("priceValidUntil")]
        public DateTime ValidUntil;
        
        [JsonProperty("itemCondition")]
        public string Condition;
        
        [JsonProperty("seller")]
        public Seller Seller;
    }
}