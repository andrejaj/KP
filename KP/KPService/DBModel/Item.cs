using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPService.DBModel
{
    public class Item
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public string Description { get; set; }
    }
}
