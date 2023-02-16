using KPService.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPService.Filter
{
    internal class AndCriteria : ICriteria
    {
        private ICriteria criteria;
        private ICriteria otherCriteria;

        public AndCriteria(ICriteria criteria, ICriteria otherCriteria)
        {
            this.criteria = criteria;
            this.otherCriteria = otherCriteria;
        }

        public IList<Author> MeetCriteria(IList<Author> authors)
        {
            var firstCriteriaAuthors = criteria.MeetCriteria(authors);
            return otherCriteria.MeetCriteria(firstCriteriaAuthors);
        }
    }
}
