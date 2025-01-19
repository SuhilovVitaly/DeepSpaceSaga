namespace DeepSpaceSaga.UI.Handlers;

public static class GameEventsHandker
{
    public static void Execute(GameSessionDTO session, TacticGameScreen tacticalScreen)
    {
        foreach (var gameEvent in session.Events)
        {
            switch (gameEvent.TriggerCommand?.Type)
            {                
                case CommandTypes.MiningOperationsResult:
                    tacticalScreen.OpenCargoUI((GameActionEvent)gameEvent.Copy());
                    break;
            }
        }
    } 
}
