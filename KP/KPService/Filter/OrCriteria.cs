using KPService.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPService.Filter
{
    internal class OrCriteria : ICriteria
    {
        private ICriteria criteria;
        private ICriteria otherCriteria;
        public OrCriteria(ICriteria criteria, ICriteria otherCriteria)
        {
            this.criteria = criteria;
            this.otherCriteria = otherCriteria;
        }

        public IList<Author> MeetCriteria(IList<Author> author)
        {
            var firstCriteriaItems = criteria.MeetCriteria(author);
            var otherCriteriaItems = otherCriteria.MeetCriteria(author);

            foreach (var otherItems in otherCriteriaItems)
            {
                if (!firstCriteriaItems.Contains(otherItems))
                {
                    firstCriteriaItems.Add(otherItems);
                }
            }

            return firstCriteriaItems;
        }
    }
}
