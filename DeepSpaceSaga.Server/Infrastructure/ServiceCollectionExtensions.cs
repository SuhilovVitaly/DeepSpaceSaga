public static class ServiceCollectionExtensions
{
    private static readonly ILog _log = LogManager.GetLogger(typeof(ServiceCollectionExtensions));

    public static IServiceCollection AddGameServer(this IServiceCollection services)
    {
        try
        {
            _log.Info("Configuring game server services...");

            services.AddTurnCalculation();
            services.AddGameState();
            services.AddNetworking();

            _log.Info("Game server services configured successfully");
            return services;
        }
        catch (Exception ex)
        {
            _log.Error("Failed to configure game server services", ex);
            throw;
        }
    }

    private static IServiceCollection AddTurnCalculation(this IServiceCollection services)
    {
        _log.Debug("Registering turn calculation services...");

        // Основной калькулятор
        //services.AddScoped<ITurnCalculator, TurnCalculator>();

        // Регистрация об��аботчиков
        RegisterHandlers(services);

        return services;
    }

    private static void RegisterHandlers(IServiceCollection services)
    {
        /*
        // PreProcessing
        services.AddScoped<IPreProcessingHandler, ValidateSessionHandler>();
        services.AddScoped<IPreProcessingHandler, ValidateCommandsHandler>();
        services.AddScoped<IPreProcessingHandler, ResourceValidationHandler>();

        // Processing
        services.AddScoped<IProcessingHandler, MovementHandler>();
        services.AddScoped<IProcessingHandler, CombatHandler>();
        services.AddScoped<IProcessingHandler, MiningHandler>();
        services.AddScoped<IProcessingHandler, TradingHandler>();

        // PostProcessing
        services.AddScoped<IPostProcessingHandler, StateUpdateHandler>();
        services.AddScoped<IPostProcessingHandler, NotificationHandler>();
        services.AddScoped<IPostProcessingHandler, PersistenceHandler>();
        */
    }

    private static IServiceCollection AddGameState(this IServiceCollection services)
    {
        /*
        services.AddSingleton<IGameStateManager, GameStateManager>();
        services.AddScoped<ISessionManager, SessionManager>();
        */
        return services;
    }

    private static IServiceCollection AddNetworking(this IServiceCollection services)
    {
        /*
        services.AddSingleton<INetworkManager, NetworkManager>();
        services.AddScoped<IClientConnectionHandler, ClientConnectionHandler>();
        */
        return services;
    }
} 