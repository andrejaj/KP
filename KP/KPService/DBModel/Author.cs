using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPService.DBModel
{
    public class Author
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Nckname { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
