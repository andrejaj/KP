using KPService.Model;
using Microsoft.Extensions.Logging;

namespace KPService
{
    public class DataScraper : IDataScraper
    {
        private readonly IService _service;
        private readonly ILogger<Service> _logger;

        public DataScraper(ILogger<Service> logger, IService service) 
        { 
            _logger= logger;
            _service = service; 
        }
        public void LoadData()
        {
            _logger.LogInformation("Started LoadData");

            //first check if need to poll and take data from db          
            var count = _service.GetPageCount();
            var items = _service.GetItems(count);
            List<Item> kpItems = new List<Item>();
            foreach (var item in items)
            {
                var kpItem = _service.GetItem(item);
                kpItems.Add(kpItem);
            }

            _logger.LogInformation("Finished LoadData");
        }
    }
}