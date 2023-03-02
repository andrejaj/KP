using KPService.DBModel;

namespace KPService
{
    public interface IRepository
    {
        IList<Author> GetAuthors();
        List<string> GetItemSkus();
        int InsertVisitedOffers(string sku, string url);
        Guid InsertItem(Item item);
        void InsertItemOffer(ItemOffer itemOffer);
        void InsertItemImages(ItemImages itemImages);
        Guid InsertSeller(Seller seller);
    }
}