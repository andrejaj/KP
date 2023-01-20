using KPService;
using KPWorker;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddTransient<IService, Service>();
        services.AddTransient<IDataScraper, DataScraper>();
    })
    .Build();

await host.RunAsync();
