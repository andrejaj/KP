using KPService.DBModel;

namespace KPService
{
    public interface IRepository
    {
        IList<Author> GetAuthors();
        List<string> GetItemIds();
        int InsertVisitedOffers(string sku);
        Guid InsertItem(Item item);
        void InsertItemOffer(ItemOffer itemOffer, Guid id);
        void InsertItemImages(ItemImages itemImages, Guid id);
        void InsertSeller(Seller seller);
    }
}