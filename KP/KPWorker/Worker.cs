using KPService;

namespace KPWorker
{
    public class Worker : BackgroundService
    {
        //private IHostApplicationLifetime _lifetime;
        private readonly ILogger<Worker> _logger;
        private readonly IDataScraper _dataScraper;
        private const int DelayInDays = 1;

        public Worker(ILogger<Worker> logger/*, IHostApplicationLifetime lifetime*/, IDataScraper dataScraper)
        {
            //_lifetime = lifetime;
            _logger = logger;
            _dataScraper = dataScraper;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    _logger.LogDebug("Worker started at: {time}", DateTimeOffset.Now);

                    _dataScraper.LoadData();

                    _logger.LogDebug("Worker finished at: {time}", DateTimeOffset.Now);

                    await Task.Delay(TimeSpan.FromSeconds(DelayInDays) /*TimeSpan.FromDays(DelayInDays)*/, stoppingToken);

                    // When completed, the entire app host will stop.
                    //_lifetime.StopApplication();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Message}", ex.Message);

                // Terminates this process and returns an exit code to the operating system.
                Environment.Exit(1);
            }
        }
    }
}