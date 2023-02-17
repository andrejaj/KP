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
        private readonly IDBService _dbService;
        private readonly IPipelineProcessor _pipelineProcessor;

        public DataScraper(ILogger<ItemService> logger, IItemService itemService, IDBService dbService, IPipelineProcessor pipelineProcessor) 
        { 
            _logger= logger ?? throw new ArgumentNullException(nameof(logger));
            _itemService = itemService ?? throw new ArgumentNullException(nameof(itemService));
            _dbService= dbService ?? throw new ArgumentNullException(nameof(dbService));
            _pipelineProcessor = pipelineProcessor ?? throw new ArgumentNullException(nameof(pipelineProcessor));
        }

        public void LoadData()
        {
            _logger.LogInformation("Started LoadData from Kp.");

            var items = _itemService.GetItems();
            var newItems = _pipelineProcessor.Process(items);
            var kpItems = newItems.Select(x => _itemService.GetItem(x)).ToList();
            _dbService.Write(kpItems);

            _logger.LogInformation("Finished LoadData from Kp.");
        }
    }
}