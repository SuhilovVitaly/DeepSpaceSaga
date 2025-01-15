namespace DeepSpaceSaga.Server;

public static class ServerStartupExtensions
{
    public static IServiceCollection AddServerServices(this IServiceCollection services)
    {
        services.AddTransient<IGameEngine, GameEngine>();
        services.AddTransient<IGameServerService, GameServerService>();
        return services;
    }
}
