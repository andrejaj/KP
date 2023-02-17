namespace KPService.PipelineFilter
{
    public class PipelineProcessor : IPipelineProcessor
    {
        private readonly AuthorFilter _authorFilter;
        private readonly NewItemFilter _newItemFilter;
        private readonly Pipeline<IEnumerable<string>> _itemSelectionPipeline;

        public PipelineProcessor(Pipeline<IEnumerable<string>> itemSelectionPipeline, NewItemFilter newItemFilter, AuthorFilter authorFilter) 
        {
            _itemSelectionPipeline = itemSelectionPipeline;
            _newItemFilter = newItemFilter;
            _authorFilter = authorFilter;
        }

        public IEnumerable<string> Process(IEnumerable<string> items)
        {
            //Register the filters to be executed
            _itemSelectionPipeline
                .Register(_newItemFilter)
                .Register(_authorFilter);

            //Start pipeline processing
            var newItems = _itemSelectionPipeline.Process(items);
            return newItems;
        }
    }
}
