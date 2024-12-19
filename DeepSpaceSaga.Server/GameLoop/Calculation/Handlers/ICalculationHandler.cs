namespace DeepSpaceSaga.Server.GameLoop.TurnCalculation.Handlers;

public interface ICalculationHandler
{
    int Order { get; }
    HandlerType Type { get; }
    SessionContext Handle(SessionContext context);
} 