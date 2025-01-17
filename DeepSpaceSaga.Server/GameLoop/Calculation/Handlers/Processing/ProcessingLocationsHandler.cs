﻿namespace DeepSpaceSaga.Server.GameLoop.Calculation.Handlers.Processing;

public class ProcessingLocationsHandler(IFlowContext context) : FlowStepBase<IFlowContext, IFlowContext>(context)
{
    public override IFlowContext Execute(IFlowContext flowContext)
    {
        foreach (var celestialObject in context.Session.SpaceMap.GetCelestialObjects())
        {
            RecalculateOneTickObjectLocation(context, celestialObject);
        }

        return context;
    }

    private void RecalculateOneTickObjectLocation(IFlowContext context, ICelestialObject celestialObject)
    {
        double tickSpeed = celestialObject.Speed / ( 1000 / context.Settings.TickInterval);

        tickSpeed *= context.Session.State.Speed;

        var position = GeometryTools.Move(
            celestialObject.GetLocation(),
            tickSpeed,
            celestialObject.Direction);

        celestialObject.PositionX = position.X;
        celestialObject.PositionY = position.Y;
    }    
}

public static class ProcessingLocationsFlowExtensions
{
    public static IFlowStep<IFlowContext, IFlowContext> ProcessingLocations(this IFlowContext context)
    {
        var factory = FlowStepFactory.Instance;
        return factory.CreateStep<ProcessingLocationsHandler>(context);
    }

    public static IFlowStep<IFlowContext, IFlowContext> ProcessingLocations(this IFlowStep<IFlowContext, IFlowContext> step)
    {
        var factory = FlowStepFactory.Instance;
        var result = step.Execute(step.FlowContext);
        return factory.CreateStep<ProcessingLocationsHandler>(result);
    }
}


