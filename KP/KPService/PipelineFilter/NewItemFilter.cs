using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KPService.PipelineFilter
{
    public class NewItemFilter : IFilter<IEnumerable<string>>
    {
        private readonly IRepository _repository;

        private HashSet<string> _visistedItems;
        private readonly Regex _idPattern = new Regex("(\\/)([0-9]+)");

        public NewItemFilter(IRepository repository) 
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _visistedItems = _repository.GetItemIds().ToHashSet();
        }
        public IEnumerable<string> Execute(IEnumerable<string> input)
        {
            if (input == null || !input.Any())
            {
                return input;
            }

            var items = new List<string>();
            if (_visistedItems.Any())
            {
                foreach (var item in input)
                {
                    var id = _idPattern.Match(item).Groups[2].Value;
                    if (!_visistedItems.Contains(id))
                    {
                        items.Add(item);
                        //for next time we know item is added
                        _repository.InsertVisitedOffers(id);
                    }
                }
            }
            else
            {
                items.AddRange(input);
                //all items are new
                items.ForEach(x => _repository.InsertVisitedOffers(_idPattern.Match(x).Groups[2].Value));
            }
  
            return items;
        }
    }
}
