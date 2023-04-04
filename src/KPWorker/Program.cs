using KPService;
using KPService.Filter;
using KPService.PipelineFilter;
using KPWorker;
using Serilog;
using System;

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
    })
    .UseSerilog()
    .Build();

await host.RunAsync();

Log.CloseAndFlush();