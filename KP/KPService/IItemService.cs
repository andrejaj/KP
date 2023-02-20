using KPService.Model;

namespace KPService
{
    public interface IItemService
    {
        Item GetItem(string url);
        List<string> GetItems(string url);
    }
}