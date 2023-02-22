using AutoMapper;
using AutoMapper.Execution;
using KPService.DBModel;
using KPService.Enum;
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

            List<string> totalItems= new List<string>();
            foreach (var url in urls)
            {
                var items = _itemService.GetItems(url);
                _logger.LogInformation($"Category price {GetPriceType(url)} has total count of items {items.Count}");
                totalItems.AddRange(items);
            };
            _logger.LogInformation($"Total items {totalItems.Count()}");

            var newItems = _pipelineProcessor.Process(totalItems);

            _logger.LogInformation($"new items processed {newItems.Count()}");

            var kpItems = newItems.Select(x => _itemService.GetItem(x)).ToList();
            _dbService.Write(kpItems);

            _logger.LogInformation("Finished LoadData from Kp.");
        }

        private PriceType GetPriceType(string url)
        {
            var regex = new Regex("priceText=(.*)&search");
            var match = regex.Match(url);
            if (match.Success) 
            {
                return ConvertEnum<PriceType>.ToConvert(match.Groups[1].Value);
            }
            else
            {
                return PriceType.Cena;
            }
        }
    }
}