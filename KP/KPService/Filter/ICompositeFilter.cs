using KPService.DBModel;

namespace KPService.Filter
{
    public interface ICompositeFilter
    {
        Author FullNameFilterOn(string text);
        IList<Author> PartialNameFilterOn(string title);
    }
}