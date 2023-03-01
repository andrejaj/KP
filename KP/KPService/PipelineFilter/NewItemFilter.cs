using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

namespace KPService.PipelineFilter
{
    public class NewItemFilter : IFilter<IEnumerable<string>>
    {
        private readonly IRepository _repository;
        private readonly Regex _idPattern = new Regex("(\\/oglas\\/)(\\d+)");
        private ILogger<NewItemFilter> _logger;

        public NewItemFilter(ILogger<NewItemFilter> logger, IRepository repository) 
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public IEnumerable<string> Execute(IEnumerable<string> input)
        {
            if (input == null || !input.Any())
            {
                return input;
            }

            var items = new List<string>();

            var _visistedItems = _repository.GetItemIds().ToHashSet();
            foreach (var item in input)
            {
                //it may need to precheck if item exists but has expired to update item 
                var id = _idPattern.Match(item).Groups[2].Value;

                if (!_visistedItems.Contains(id))
                {
                    items.Add(item);
                    //for next time we know item is added, but this won't work for duplicate is found in same list
                    _repository.InsertVisitedOffers(id, item);
                }
                else
                {
                    _logger.LogInformation($"duplicate item found {id} - {item}");
                }
            }
  
            return items;
        }
    }
}
