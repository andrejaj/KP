using KPService;
using KPService.Filter;
using KPService.PipelineFilter;
using KPWorker;
using Serilog;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

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
    })
    .UseSerilog()
    .Build();

await host.RunAsync();

Log.CloseAndFlush();