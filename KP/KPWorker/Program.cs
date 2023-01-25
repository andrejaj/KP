using KPService;
using KPWorker;
using Microsoft.Extensions.Configuration.Json;
using NReco.Logging.File;
using System.Configuration;

IHost host = Host.CreateDefaultBuilder(args)
    //.ConfigureLogging((hostContext, builder) =>
    //{
    //    builder.AddConfiguration(hostContext.Configuration.GetSection("Logging"));
    //    builder.AddFile("");
    //}
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<Worker>();
        services.AddTransient<IService, Service>();
        services.AddTransient<IDataScraper, DataScraper>();
        services.AddSingleton<IRepository>( x=> new Repository(hostContext.Configuration.GetConnectionString("KPConnection")));

        //services.AddLogging(loggingBuilder =>
        //{
        //    var loggingSection = hostContext.Configuration.GetSection("Logging");
        //    var f = loggingBuilder.AddFile(loggingSection);
        //});

        //services.AddLogging(loggingBuilder => 
        //{ var loggingSection = hostContext.Configuration.GetSection("Logging"); 
        //    loggingBuilder.AddFile(loggingSection); });
        Action<FileLoggerOptions> configure = (p) =>
        {
            new FileLoggerOptions() { MaxRollingFiles = 10, FileSizeLimitBytes = 1, Append = true };
        };
        //services.AddLogging(loggingBuilder =>
        //{
        //    var loggingSection = hostContext.Configuration.GetSection("Logging");
        //    loggingBuilder.AddFile(loggingSection);
        //});
        
        services.AddLogging(loggingBuilder =>
        {

            loggingBuilder.AddFile("app.log", configure);
        });
    })
    //.ConfigureLogging((hostingContext, logging) => {
    //    logging.AddConfiguration(hostingContext.Configuration.GetSection("File"));
    //    logging.AddConsole();
    //})
    .Build();

await host.RunAsync();
