using KPService.DBModel;
using KPService.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPService.Filter
{
    internal class CriteriaLastname : ICriteria
    {
        private string searchCriteria;
        public CriteriaLastname(string searchCriteria)
        {
            this.searchCriteria = searchCriteria;
        }
        public IList<Author> MeetCriteria(IList<Author> authors)
        {
            IList<Author> authorsData = new List<Author>();
            foreach (var item in authors)
            {
                if (searchCriteria.ToLower().RemoveDiacriticalMarks().Contains(item.LastName.ToLower()))
                {
                    authorsData.Add(item);
                }
            }

            return authorsData;
        }
    }
}
