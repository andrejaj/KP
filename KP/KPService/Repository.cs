using Dapper;
using KPService.DBModel;
using KPService.Model;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace KPService
{
    public class Repository : IRepository
    {
        private readonly string _connectionString;
        public Repository(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public List<string> GetItemIds()
        {
            List<string>? itemIds = null;

            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    itemIds = db.Query<string>(@"SELECT Sku FROM [KPProducts].[dbo].[Item]").ToList();
                }
            }
            catch (Exception ex)
            {
                //log
            }
            return itemIds ?? new List<string>();
        }

        public List<Author> GetAuthors()
        {
            List<Author>? authors = null;

            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    authors = db.Query<Author>(@"SELECT Id, FirstName, LastName, NickName FROM [KPProducts].[dbo].[Author]").ToList();
                }
            }
            catch (Exception ex)
            {
                //log
            }
            return authors ?? new List<Author>();
        }

        public void InsertAuthor(Author author)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var count = db.Execute(@"insert Author(FirstName, LastName, NickName) values (@firstname, @lastname, @nickname)", new { firstname = author.Firstname, lname = author.Lastname, nickname = author.Nckname });
                }
            }
            catch (Exception ex)
            {
                //log
            }
        }

        public void InsertItem(DBModel.Item item)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var count = db.Execute(@"insert Item(Sku, Description, CurrencyId, Price, PriceTypeId, ConditionId, SellerId, StatusId, PriceValidUntil) values (@sku, @description, @currencyId, @price, @priceTypeId, @conditionId, @sellerId, @statusId, @priceValidUntil)",
                        new { sku = item.Sku, description = item.Description, currencyId = item.CurrencyId, price = item.Price, priceTypeId = item.PriceTypeId, conditionId = item.ConditionId, sellerId = item.SellerId, statusId = item.StatusId, priceValidUntil = item.PriceValidUntil });
                }
            }
            catch (Exception ex)
            {
                //log
            }
        }

        public void InsertItemImages(List<ItemImage> itemImages)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    //do as db trasaction
                    foreach (var itemImage in itemImages)
                    {
                        var count = db.Execute(@"insert ItemImage(Url, ItemId) values (@url, @itemId)", new { url = itemImage.Url, itemId = itemImage.ItemId });
                    }
                }
            }
            catch (Exception ex)
            {
                //log
            }
        }

        public void InsertSeller(DBModel.Seller seller)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var count = db.Execute(@"insert Seller(Name, Phone) values (@name, @phone)", new { name = seller.Name, phone = seller.Phone });
                }
            }
            catch (Exception ex)
            {
                //log
            }
        }
    }
}
