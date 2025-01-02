namespace DeepSpaceSaga.Server.GameLoop;

public class TurnExecutor
{
    private static readonly ILog _log = LogManager.GetLogger(typeof(TurnExecutor));

    public static IFlowContext ExecuteTick(IFlowContext context)
    {        
        return FlowTickExecutor.Execute(context);
    }

    public static IFlowContext Execute(IFlowContext context)
    {
        IFlowContext processingSession = new SessionContext(
            context.Session.Copy(),
            context.EventsSystem.Clone(),
            context.Metrics,
            context.Randomizer,
            context.Settings);

        context.Session.Events = new GameActionEvents([]);

        for (var i = 0; i < processingSession.Session.State.Speed; i++)
        {
            var stopwatch = Stopwatch.StartNew();

            processingSession = FlowTurnExecutor.Execute(context);

            stopwatch.Stop();

            double milliseconds = stopwatch.ElapsedTicks * 1000.0 / Stopwatch.Frequency;

            context.Metrics.AddMilliseconds(Metrics.CalculationTurnAvg, milliseconds);

            _log.Debug($"Calculation is {stopwatch.ElapsedTicks} Avg is {context.Metrics.GetAverageMillisecondst(Metrics.CalculationTurnAvg)}");
        }        

        return processingSession;
    }
}
