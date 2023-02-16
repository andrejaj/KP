using KPService.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace KPService.Filter
{
    internal class CompositeFilter : ICompositeFilter
    {
        private readonly IRepository _repository;

        private IList<Author> Authors => _repository.GetAuthors();

        public CompositeFilter(IRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Author FullNameFilterOn(string text)
        {
            ICriteria firstName = new CriteriaFirstname(text);
            ICriteria lastName = new CriteriaLastname(text);
            ICriteria fullName = new AndCriteria(firstName, lastName);
            var searchedData = fullName.MeetCriteria(Authors);
            return searchedData.FirstOrDefault();
        }

        public IList<Author> PartialNameFilterOn(string text)
        {
            ICriteria firstName = new CriteriaFirstname(text);
            ICriteria lastName = new CriteriaLastname(text);
            ICriteria fullName = new OrCriteria(firstName, lastName);
            var searchedData = fullName.MeetCriteria(Authors);
            return searchedData;
        }
    }
}
