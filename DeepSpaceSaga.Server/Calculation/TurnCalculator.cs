namespace DeepSpaceSaga.Server.Calculation;

public class TurnCalculator
{
    public GameSession Execute(GameSession session, GameEventsSystem eventsSystem, int ticks = 1)
    {
        var processingSession = session.Copy();

        for (var i = 0; i < ticks; i++)
        {
            processingSession = TurnExecution(session, eventsSystem);
        }

        return processingSession;
    }

    internal GameSession TurnExecution(GameSession session, GameEventsSystem eventsSystem)
    {
        session = PreProcessing.Execute(session, eventsSystem);

        session = Processing.Execute(session, eventsSystem);

        session = PostProcessing.Execute(session, eventsSystem);

        return session;
    }

    //public GameSession ExecuteXXX(GameSession session, GameEventsSystem eventsSystem, int ticks = 1)
    //{
    //    var processingSession = session.Copy();

    //    foreach (Command command in eventsSystem.Commands)
    //    {
    //        new NavigationCommandsProcessing().Execute(processingSession, command);
    //    }

    //    for (var i = 0; i < ticks; i++)
    //    {
    //        //processingSession = new CalculateLocationsHandler().Execute(processingSession);

    //        //processingSession = new GameEventsProcessing().Execute(processingSession, eventsSystem, ticks);

    //        processingSession = PreProcessing.Execute(processingSession, eventsSystem, ticks);

    //        processingSession = new Processing().Execute(processingSession, eventsSystem, ticks);

    //        processingSession = new PostProcessing().Execute(processingSession, eventsSystem, ticks);
    //    }

    //    return processingSession;
    //}
}
