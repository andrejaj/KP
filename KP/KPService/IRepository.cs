using KPService.DBModel;

namespace KPService
{
    public interface IRepository
    {
        IList<Author> GetAuthors();
        List<string> GetItemIds();
        int InsertVisitedOffers(string sku);
        Guid InsertItem(Item item);
        void InsertItemOffer(ItemOffer itemOffer);
        void InsertItemImages(ItemImages itemImages);
        Guid InsertSeller(Seller seller);
    }
}