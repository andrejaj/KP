namespace KPService.PipelineFilter
{
    public interface IPipelineProcessor
    {
        IEnumerable<string> Process(IEnumerable<string> items);
    }
}