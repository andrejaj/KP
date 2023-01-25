using KPService.DBModel;

namespace KPService
{
    public interface IRepository
    {
        List<Author> GetAuthors();
        List<string> GetItemIds();
        void InsertAuthor(Author author);
        void InsertItem(Item item);
        void InsertItemImages(List<ItemImage> itemImages);
        void InsertSeller(Seller seller);
    }
}