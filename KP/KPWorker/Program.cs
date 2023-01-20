using KPService;
using KPWorker;
using NReco.Logging.File;

IHost host = Host.CreateDefaultBuilder(args)
    //.ConfigureLogging((hostContext, builder) =>
    //{
    //    builder.AddConfiguration(hostContext.Configuration.GetSection("Logging"));
    //    builder.AddFile("");
    //})
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<Worker>();
        services.AddTransient<IService, Service>();
        services.AddTransient<IDataScraper, DataScraper>();

        Action<FileLoggerOptions> configure = (p) =>
        {
            new FileLoggerOptions() { MaxRollingFiles = 10, FileSizeLimitBytes = 1, Append = true  };
        };
        //services.AddLogging(loggingBuilder =>
        //{
        //    var loggingSection = hostContext.Configuration.GetSection("File");
        //    loggingBuilder.AddFile(loggingSection);
        //});
        //services.AddLogging();
        services.AddLogging(loggingBuilder =>
        {

            loggingBuilder.AddFile("app.log", configure);
        });
    })
    .Build();

await host.RunAsync();
