namespace KPService.DBModel
{
    public class ItemImages
    {
        public Guid ItemId { get; set; }
        public IList<string> Images { get; set; }
    }
}