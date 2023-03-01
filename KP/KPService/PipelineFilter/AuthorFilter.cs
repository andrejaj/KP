using KPService.DBModel;
using KPService.Filter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KPService.PipelineFilter
{
    public class AuthorFilter : IFilter<IEnumerable<string>>
    {
        private readonly IRepository _repository;
        private readonly IList<Author> _authors;
        private readonly Regex _titlePattern = new Regex("(godina\\/)(.*)(\\/oglas)");
        private readonly ICompositeFilter _compositeFilter;
        private readonly ILogger<AuthorFilter> _logger;

        public AuthorFilter(ILogger<AuthorFilter> logger, IRepository repository, ICompositeFilter compositeFilter)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _authors = _repository.GetAuthors();
            _compositeFilter = compositeFilter;
        }

        public IEnumerable<string> Execute(IEnumerable<string> input)
        {
            if (input == null || !input.Any())
            {
                return input;
            }

            var items = new List<string>();
            //authors that we will filter on
            if (_authors.Any())
            {
                foreach (var item in input)
                {
                    var title = _titlePattern.Match(item).Groups[2].Value;
                    _logger.LogInformation($"title: {title}");
                    var names = title.Split('-').Select(x => x.ToLower()).ToList();

                    var author = _compositeFilter.FullNameFilterOn(title);
                    if(author != null) 
                    {
                        items.Add(item);
                    }
                    else
                    {
                        var authors = _compositeFilter.PartialNameFilterOn(title).ToList();
                        if (authors.Any())
                        {
                            _logger.LogInformation($"-----------For {title}------------");
                            authors.ForEach(x => _logger.LogInformation($"Found partial match based on author's first name {x.FirstName} or last name {x.LastName}"));
                            _logger.LogInformation($"----------------------------------");
                        }
                    }                 
                }
            }
            return items;
        }
    }
}