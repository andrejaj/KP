using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KPService.Model
{
    public class Item
    {


        [JsonProperty("name")]
        public string Title { get; set; }
        
        [JsonProperty("image")]
        public IList<string> Images { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("sku")]
        public string Sku { get; set; }
        
        [JsonProperty("offers")]
        public ItemOffer ItemOffer { get; set; }
    }
}
