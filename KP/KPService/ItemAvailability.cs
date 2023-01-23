using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPService
{
    internal enum ItemAvailability
    {
        BackOrder,
        Discontinued,
        InStock,
        InStoreOnly,
        LimitedAvailability,
        OnlineOnly,
        OutOfStock,
        PreOrder,
        PreSale,
        SoldOut,
    }
}
