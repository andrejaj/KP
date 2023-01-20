using KPService.Model;

namespace KPService
{
    public class DataScraper : IDataScraper
    {
        private readonly IService _service;
        public DataScraper(IService service) => _service = service;
        public void LoadData()
        {
            //first check if need to poll and take data from db          
            var count = _service.GetPageCount();
            var items = _service.GetItems(count);
            List<Item> kpItems = new List<Item>();
            foreach (var item in items)
            {
                var kpItem = _service.GetItem(item);
                kpItems.Add(kpItem);
            }
        }
    }
}