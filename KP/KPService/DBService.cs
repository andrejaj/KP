using AutoMapper;
using Microsoft.Extensions.Logging;

namespace KPService
{
    public class DBService : IDBService
    {
        private readonly ILogger<ItemService> _logger;
        private readonly IRepository _repository;
        private readonly IMapperConfigurator _mapperConfigurator;
        private readonly IMapper _mapper;
        public DBService(ILogger<ItemService> logger, IRepository repository, IMapperConfigurator mapperConfigurator) 
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapperConfigurator = mapperConfigurator ?? throw new ArgumentNullException(nameof(_mapperConfigurator));
            _mapper = _mapperConfigurator.GetMapper();
        }

        public void Write(List<Model.Item> items)
        {
            foreach (var kpItem in items)
            {
                try
                {
                    //mapping objects to dto's could be converted to extension methods and passedto repo striaght
                    var item = _mapper.Map<DBModel.Item>(kpItem);
                    var itemOffer = _mapper.Map<DBModel.ItemOffer>(kpItem);
                    var itemImages = _mapper.Map<DBModel.ItemImages>(kpItem);
                    var seller = _mapper.Map<DBModel.Seller>(kpItem);

                    //insert dto's into tables
                    var id = _repository.InsertItem(item);
                    var sellerId = _repository.InsertSeller(seller);
                    itemOffer.SellerId = sellerId;
                    itemOffer.ItemId = id;
                    _repository.InsertItemOffer(itemOffer);
                    itemImages.ItemId = id;
                    _repository.InsertItemImages(itemImages);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Write Item {kpItem.Title} with SKu:{kpItem.Sku} failed to map or write to the database.");
                }
            }
        }
    }
}
