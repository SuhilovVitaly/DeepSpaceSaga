namespace DeepSpaceSaga.UI.Handlers;

public static class GameEventsHandker
{
    public static void Execute(GameSession session, Form1 tacticalScreen)
    {
        foreach (var gameEvent in session.Events)
        {
            switch (gameEvent.TriggerCommand?.Type)
            {                
                case CommandTypes.MiningOperationsResult:
                    tacticalScreen.OpenCargoUI(gameEvent.Copy());
                    break;
            }
        }
    } 
}
