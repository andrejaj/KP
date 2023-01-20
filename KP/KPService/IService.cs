using KPService.Model;

namespace KPService
{
    public interface IService
    {
        Item GetItem(string url);
        List<string> GetItems(int count);
        int GetPageCount();
    }
}