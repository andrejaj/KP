using AutoMapper;
using AutoMapper.Execution;
using KPService.DBModel;
using KPService.Helper;
using KPService.Model;
using KPService.PipelineFilter;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace KPService
{
    public class DataScraper : IDataScraper
    {
        private readonly IItemService _itemService;
        private readonly ILogger<ItemService> _logger;
        private readonly IRepository _repository;
        //private readonly IMapperConfigurator _mapperConfigurator;
        private readonly IDBService _dbService;

        public DataScraper(ILogger<ItemService> logger, IItemService itemService, IRepository repository, IDBService dbService/*, IMapperConfigurator mapperConfigurator*/) 
        { 
            _logger= logger ?? throw new ArgumentNullException(nameof(logger));
            _itemService = itemService ?? throw new ArgumentNullException(nameof(itemService)); 
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _dbService= dbService ?? throw new ArgumentNullException(nameof(dbService));
            //_mapperConfigurator = mapperConfigurator ?? throw new ArgumentNullException(nameof(_mapperConfigurator));
        }

        public void LoadData()
        {
            _logger.LogInformation("Started LoadData");

            var items = _itemService.GetItems();

            //Construct the Pipeline object
            var itemStatusPipeline = new ItemSelectionPipeline();

            //Register the filters to be executed
            itemStatusPipeline
                .Register(new NewItemFilter(_repository))
                //.Register(new AuthorFilter(null, _repository, null));

            //Start pipeline processing
            var newItems = itemStatusPipeline.Process(items);
            var kpItems = newItems.Select(x => _itemService.GetItem(x)).ToList();
            _dbService.Write(kpItems);

            _logger.LogInformation("Finished LoadData");
        }
    }
}