using KPService.Extensions;
using KPService.Model;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using System.Text.RegularExpressions;
using System.Xml;

namespace KPService
{
    public class ItemService : IItemService
    {
        private readonly ILogger<ItemService> _logger;
        private readonly Configuration _myConfiguration;

        public ItemService(ILogger<ItemService> logger, Configuration myConfiguration)
        {
            _logger = logger;
            _myConfiguration = myConfiguration;
        }

        private int GetPageCount()
        {
            int count = 0;
            using (var client = new RestClient())
            {
                try
                {
                    var request = new RestRequest(_myConfiguration.KPUrl, Method.Get);
                    var response = client.Execute(request);
                    var content = ExtractValue(response.Content);
                    count = CalculatePageCount(content);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error occured retriving page count");
                }
            }
            return count;
        }

        private string ExtractValue(string content)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(content);
            var docs = doc.GetElementsByTagName("script");
            var node = docs.Cast<XmlNode>().Take(1).Single();
            return node.InnerText;
        }

        private int CalculatePageCount(string text)
        {
            const int maxItems = 30;
            var pattern = @"(\d.\d+) rezultata";
            Regex rg = new Regex(pattern);
            var match = rg.Match(text);
            var totalCount = double.Parse(match.Groups[1].Value.Replace(".", ""));
            int pageCount = (int)Math.Ceiling(totalCount / maxItems);
            return pageCount;
        }

        public List<string> GetItems()
        {
            var list = new List<string>();
            
            var count = GetPageCount();
            for (int i = 1; i <= count; i++)
            {
                try
                {
                    using (var client = new RestClient())
                    {
                        var request = new RestRequest(_myConfiguration.KPUrl + "&page="+i, Method.Get);//SearchUri + @"&page={i}", Method.Get);
                        var response = client.Execute(request);
                        var content = response.Content;
                        var newItems = ExtractItems(content);
                        list.AddRange(newItems);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error occured getting items");
                }
            }
            return list;
        }

        private List<string> ExtractItems(string text)
        {
            var doc = new XmlDocument();
            doc.LoadXml(text);
            var docs = doc.GetElementsByTagName("script");
            var nodes = new List<XmlNode>(docs.Cast<XmlNode>().Take(2));
            //second node has a list
            var nodeContent = JsonConvert.DeserializeObject<dynamic>(nodes[1].InnerText);

            List<string> items = new List<string>();
            foreach (var item in nodeContent.itemListElement)
            {
                items.Add(item.url.ToString());
            }
            return items;
        }

        private Item ExtractItem(string content)
        {
            var doc = new XmlDocument();
            doc.LoadXml(content);
            var docs = doc.GetElementsByTagName("script");
            var node = new List<XmlNode>(docs.Cast<XmlNode>().Take(1)).Single();
            return JsonConvert.DeserializeObject<Item>(node.InnerText);
        }

        public Item GetItem(string url)
        {
            Item item = null;

            try
            {
                using (var client = new RestClient())
                {
                    var request = new RestRequest(url, Method.Get);
                    var response = client.Execute(request);
                    var content = response.Content.CleanContent();
                    item = ExtractItem(content);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured getting item with uri:" + url);
            }
            return item;
        }
    }
}
