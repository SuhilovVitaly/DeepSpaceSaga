namespace DeepSpaceSaga.Server.Calculation;

public class TurnCalculator
{
    public GameSession Execute(GameSession session, GameEventsSystem eventsSystem, int ticks = 1)
    {
        var processingSession = session.Copy();

        //processingSession = new GameEventsProcessing().Execute(processingSession, eventsSystem, ticks);

        //processingSession = new PreProcessing().Execute(processingSession, eventsSystem, ticks);

        //processingSession = new Processing().Execute(processingSession, eventsSystem, ticks);

        //processingSession = new PostProcessing().Execute(processingSession, eventsSystem, ticks);

        return processingSession;
    }    
}
