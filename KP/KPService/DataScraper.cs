using KPService.Enum;
using KPService.Extensions;
using KPService.PipelineFilter;
using Microsoft.Extensions.Logging;

namespace KPService
{
    public class DataScraper : IDataScraper
    {
        private readonly IItemService _itemService;
        private readonly ILogger<ItemService> _logger;
        private readonly IDBService _dbService;
        private readonly IPipelineProcessor _pipelineProcessor;
        private readonly Configuration _myConfiguration;

        public DataScraper(ILogger<ItemService> logger, IItemService itemService, IDBService dbService, IPipelineProcessor pipelineProcessor, Configuration myConfiguration) 
        { 
            _logger= logger ?? throw new ArgumentNullException(nameof(logger));
            _itemService = itemService ?? throw new ArgumentNullException(nameof(itemService));
            _dbService= dbService ?? throw new ArgumentNullException(nameof(dbService));
            _pipelineProcessor = pipelineProcessor ?? throw new ArgumentNullException(nameof(pipelineProcessor));
            _myConfiguration = myConfiguration;
        }

        public void LoadData()
        {
            _logger.LogInformation("Started LoadData from Kp.");

            var urls = _myConfiguration.KPUrls;

            foreach (var url in urls)
            {
                _logger.LogInformation("------------------------");
                var items = _itemService.GetItems(url);
                var priceType = url.GetPriceType();
                _logger.LogInformation($"Category price {priceType} has total count of items {items.Count}");

                var newItems = _pipelineProcessor.Process(items); 

                _logger.LogInformation($"Filtered count {newItems.Count()} in {priceType} category processed.");

                var kpItems = newItems.Select(x => _itemService.GetItem(x)).ToList();
                //converting no price items to correct type
                if(!priceType.Equals(PriceType.Cena))
                {
                    kpItems.ForEach(x => x.ItemOffer.Price = priceType.ToString());
                }

                _dbService.Write(kpItems);
                _logger.LogInformation("------------------------");
            };
            _logger.LogInformation("Finished LoadData from Kp.");
        }
    }
}