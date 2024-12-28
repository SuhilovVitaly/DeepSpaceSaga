using log4net.Config;
using Microsoft.AspNetCore.Builder;

public class Program
{
    private static readonly ILog _log = LogManager.GetLogger(typeof(Program));

    public static async Task Main(string[] args)
    {
        try
        {
            var builder = WebApplication.CreateBuilder(args);

            // Конфигурация log4net
            XmlConfigurator.Configure(new FileInfo("log4net.config"));
            _log.Info("Starting Deep Space Saga server...");

            // Добавление сервисов
            //builder.Services.AddGameServer();

            var app = builder.Build();

            // Конфигурация middleware
            app.UseWebSockets();
            app.UseRouting();

            await app.RunAsync();
        }
        catch (Exception ex)
        {
            _log.Fatal("Fatal error during server startup", ex);
            throw;
        }
    }
} 