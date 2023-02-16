using KPService.DBModel;
using KPService.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPService.Filter
{
    internal class CriteriaFirstname : ICriteria
    {
        private string searchCriteria;
        public CriteriaFirstname(string searchCriteria)
        {
            this.searchCriteria = searchCriteria;
        }
        public IList<Author> MeetCriteria(IList<Author> authors)
        {
            IList<Author> authorsData = new List<Author>();
            foreach (var item in authors)
            {
                if (searchCriteria.ToLower().RemoveDiacriticalMarks().Contains(item.FirstName.ToLower()))
                {
                    authorsData.Add(item);
                }
            }

            return authorsData;
        }
    }
}
