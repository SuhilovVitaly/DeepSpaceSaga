namespace DeepSpaceSaga.UI.Handlers;

public static class GameEventsHandker
{
    public static void Execute(GameSession session, TacticGameScreen tacticalScreen)
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
