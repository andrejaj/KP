using KPService;
using KPService.Filter;
using KPService.PipelineFilter;
using KPWorker;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<Worker>();
        services.AddSingleton(hostContext.Configuration.GetSection("myConfiguration").Get<Configuration>());
        services.AddSingleton<IItemService, ItemService>();
        services.AddSingleton<IMapperConfigurator, MapperConfigurator>();
        services.AddSingleton<IDBService, DBService>();
        services.AddSingleton<IDataScraper, DataScraper>();
        services.AddSingleton<IRepository>(x => new Repository(x.GetRequiredService<ILogger<Repository>>(), hostContext.Configuration.GetConnectionString("KPConnection")));

        services.AddSingleton<ICompositeFilter, CompositeFilter>();
        services.AddSingleton<NewItemFilter>();
        services.AddSingleton<AuthorFilter>();
        services.AddSingleton<Pipeline<IEnumerable<string>>, ItemSelectionPipeline>();
        services.AddSingleton<IPipelineProcessor, PipelineProcessor>();

        services.AddLogging(loggingBuilder =>
        {
            var loggingSection = hostContext.Configuration.GetSection("Logging");
            loggingBuilder.AddFile(loggingSection);
        });

    })
    .Build();

await host.RunAsync();