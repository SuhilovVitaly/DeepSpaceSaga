﻿namespace DeepSpaceSaga.Server.GameLoop.Calculation.Handlers.PostProcessing;

public class PostProcessingCommandCleanerHandler : BaseHandler, ICalculationHandler
{
    /// <summary>
    /// Defines the order of handler execution
    /// </summary>
    public int Order => int.MaxValue;

    /// <summary>
    /// Type of the handler
    /// </summary>
    public HandlerType Type => HandlerType.PostProcessing;

    /// <summary>
    /// Processes the session context
    /// </summary>
    /// <param name="context">Session context</param>
    /// <returns>Processed session context</returns>
    public SessionContext Handle(SessionContext context)
    {
        context.EventsSystem = RemoveFinishedCommands(context.EventsSystem);
        return context;
    }

    /// <summary>
    /// Removes all commands with PostProcess status from the events system
    /// </summary>
    /// <param name="eventsSystem">Game events system</param>
    /// <returns>Updated game events system</returns>
    internal GameEventsSystem RemoveFinishedCommands(GameEventsSystem eventsSystem)
    {
        eventsSystem.Commands = new ConcurrentQueue<Command>(
            eventsSystem.Commands.Where(cmd => cmd.Status != CommandStatus.PostProcess));
            
        return eventsSystem;
    }
}
