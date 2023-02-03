using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPService.DBModel
{
    public class ItemOffer
    {
        public Guid Id { get; set; }
        public int Sku { get; set; }
        public Guid ItemId { get; set; }
        public short CurrencyId { get; set; } 
        public int Price { get; set; } 
        public short? PriceTypeId { get; set; }
        public short ConditionId { get; set; } 
        public int SellerId { get; set; } 
        public short StatusId { get; set; } 
        public DateTime ValidUntil { get; set; }
    }
}
