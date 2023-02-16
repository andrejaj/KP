using Dapper;
using KPService.DBModel;
using KPService.Model;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

//using System.Transactions;

//using (var transactionScope = new TransactionScope())
//{
//    DoYourDapperWork();
//    transactionScope.Complete();
//}

namespace KPService
{
    public class Repository : IRepository
    {
        private readonly ILogger<Repository> _logger;
        private readonly string _connectionString;
        public Repository(ILogger<Repository> logger, string connectionString)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public List<string> GetItemIds()
        {
            List<string>? itemIds = null;

            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    itemIds = db.Query<string>(@"SELECT Sku FROM [KPProducts].[dbo].[VisitedOffers]").ToList();
                }
            }
            catch (Exception ex)
            {
                
            }
            return itemIds ?? new List<string>();
        }

        public IList<Author> GetAuthors()
        {
            IList<Author>? authors = null;

            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    authors = db.Query<Author>(@"SELECT Id, FirstName, LastName, NickName FROM [KPProducts].[dbo].[Author]").ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetAuthors failed to retrive items.");
            }
            return authors ?? new List<Author>();
        }

        //public string InsertAuthor(Author author)
        //{
        //    try
        //    {
        //        using (IDbConnection db = new SqlConnection(_connectionString))
        //        {
        //            var id = db.QuerySingle<Guid>(@"insert Author(FirstName, LastName, NickName) OUTPUT INSERTED.Id values (@firstname, @lastname, @nickname)", new { firstname = author.Firstname, lastname = author.Lastname, nickname = author.Nckname });
        //            return id.ToString();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //log
        //    }
        //    return null;
        //}

        public int InsertVisitedOffers(string sku)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var count = db.Execute(@"INSERT INTO VisitedOffers (Sku) VALUES (@sku)", new { sku = sku });
                    return count;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"VisitedOffers failed to insert VisitedOffers {sku}");
            }

            return 0;
        }

        public Guid InsertItem(DBModel.Item item)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var id = db.QuerySingle<Guid>(@"INSERT INTO Item(AuthorId, Title, Description) OUTPUT INSERTED.Id VALUES (@authorId, @title, @description)",
                        new { authorId = item.AuthorId, title = item.Title, description = item.Description});
                    return id;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"InsertItem failed to insert item {item.Title}");
            }

            return Guid.Empty;
        }

        public void InsertItemOffer(DBModel.ItemOffer itemOffer)
        {
            //note seller id should be guid
            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var count = db.Execute(@"INSERT INTO ItemOffer(Sku, ItemId, CurrencyId, Price, PriceTypeId, ConditionId, SellerId, StatusId, ValidUntil, Url) VALUES (@sku, @itemId, @currencyId, @price, @priceTypeId, @conditionId, @sellerId, @statusId, @validUntil, @url)",
                        new { sku = itemOffer.Sku, itemId = itemOffer.ItemId, currencyId = itemOffer.CurrencyId, price = itemOffer.Price, priceTypeId = itemOffer.PriceTypeId, conditionId = itemOffer.ConditionId, sellerId = itemOffer.SellerId, statusId = itemOffer.StatusId, validUntil = itemOffer.ValidUntil, url = itemOffer.Url });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"InsertItemOffer failed to insert item with {itemOffer.ItemId} and {itemOffer.Sku}");
            }
        }

        public void InsertItemImages(ItemImages itemImages)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    foreach (var image in itemImages.Images)
                    {
                        var count = db.Execute(@"INSERT INTO ItemImage(Url, ItemId) VALUES (@url, @itemId)", new { url = image, itemId = itemImages.ItemId });
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"InsertItemImages failed to insert images with item id {itemImages.ItemId}");
            }
        }

        public Guid InsertSeller(DBModel.Seller seller)
        {
            try
            {
                var s = GetSeller(seller.Name);
                if (s != null)
                {
                    return s.Id;
                }
                else 
                {
                    using (IDbConnection db = new SqlConnection(_connectionString))
                    {
                        //if seller exists return id
                        var id = db.QuerySingle<Guid>(@"INSERT INTO Seller(Name, Phone) OUTPUT INSERTED.Id VALUES (@name, @phone)", new { name = seller.Name, phone = seller.Phone });
                        return id;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"InsertSeller failed to insert {seller.Name}");
            }

            return Guid.Empty;
        }

        public DBModel.Seller GetSeller(string name)
        {
            DBModel.Seller seller = null;

            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var sellers = db.Query<DBModel.Seller>($"SELECT ID, Name, Phone FROM [KPProducts].[dbo].[Seller] Where Name Like '{name}'");
                    seller = sellers.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetSeller failed to retrive item.");
            }
            return seller;
        }
    }
}
