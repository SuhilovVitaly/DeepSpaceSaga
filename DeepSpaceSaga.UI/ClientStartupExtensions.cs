namespace DeepSpaceSaga.UI;

public static class ClientStartupExtensions
{
    public static IServiceCollection AddClientServices(this IServiceCollection services)
    {
        services.AddScoped<IScreenInfo, ScreenParameters>();
        services.AddScoped<IOuterSpace, OuterSpace>();
        services.AddScoped<ILocalGameServerOptions, LocalGameServerOptions>();
        services.AddScoped<IServerMetrics, ServerMetrics>();
        services.AddTransient<ISaveLoadService, SaveLoadService>();
        services.AddScoped<IGenerationTool, GenerationTool>();
        services.AddScoped<IEventManager, EventManager>();
        services.AddScoped<IScreenManager, ScreenManager>();
        services.AddScoped<IGameManager, GameManager>();        

        return services;
    }

    public static IServiceCollection AddClientScreens(this IServiceCollection services)
    {
        services.AddScoped<BackgroundScreen>();
        services.AddTransient<MainMenuScreen>();
        services.AddTransient<GameMenuScreen>();
        services.AddTransient<SaveGameScreen>();
        services.AddTransient<LoadGameScreen>();
        services.AddScoped<TacticGameScreen>();

        return services;
    }
}
