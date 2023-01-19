namespace KPService
{
    public class Class1
    {
		private void GetData()
		{
			 //first check if need to poll and take data from db

        var kpService = new KPService.Service.KP();

        var count = kpService.GetPageCount();
        var items = kpService.GetItems(count);
        List<Item> kpItems = new List<Item>();
        foreach(var item in items)
        {
            var kpItem = kpService.GetItem(item);
            kpItems.Add(kpItem);
        }
    }
}