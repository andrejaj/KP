using KPService.DBModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPService.Filter
{
    internal interface ICriteria
    {
        IList<Author> MeetCriteria(IList<Author> authors);
    }
}
