using KPService;
using KPService.Filter;
using KPService.PipelineFilter;
using KPWorker;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<Worker>();
        services.AddSingleton(hostContext.Configuration.GetSection("myConfiguration").Get<Configuration>());
        services.AddTransient<IItemService, ItemService>();
        services.AddTransient<IMapperConfigurator, MapperConfigurator>();
        services.AddTransient<IDBService, DBService>();
        services.AddTransient<IDataScraper, DataScraper>();
        services.AddTransient<IRepository>(x => new Repository(x.GetRequiredService<ILogger<Repository>>(), hostContext.Configuration.GetConnectionString("KPConnection")));

        services.AddTransient<ICompositeFilter, CompositeFilter>();
        services.AddTransient<NewItemFilter>();
        services.AddTransient<AuthorFilter>();
        services.AddTransient<Pipeline<IEnumerable<string>>, ItemSelectionPipeline>();
        services.AddTransient<IPipelineProcessor, PipelineProcessor>();

        services.AddLogging(loggingBuilder =>
        {
            var loggingSection = hostContext.Configuration.GetSection("Logging");
            loggingBuilder.AddFile(loggingSection);
        });

    })
    .Build();

await host.RunAsync();