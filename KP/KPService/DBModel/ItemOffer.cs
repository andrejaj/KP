using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPService.DBModel
{
    public class ItemOffer
    {
        public Guid ItemId { get; set; }
        public Guid SellerId { get; set; } 
        public int Sku { get; set; }
        public short CurrencyId { get; set; } 
        public double Price { get; set; } 
        public short? PriceTypeId { get; set; }
        public short ConditionId { get; set; } 
        public short StatusId { get; set; } 
        public DateTime ValidUntil { get; set; }
        public string Url { get; set; }
    }
}
