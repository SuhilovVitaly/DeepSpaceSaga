namespace DeepSpaceSaga.Tests.TestsFramework;

internal class Generator
{
    public static LocalGameServer LocalGameServer()
    {
        var _gameServer = new LocalGameServer();
        _gameServer.SessionInitialization();

        return _gameServer;
    }
}
