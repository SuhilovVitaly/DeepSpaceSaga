namespace DeepSpaceSaga.Common.Tools.Telemetry;

public enum Metrics
{
    ReceivedCommand,
    ProcessingNavigationCommand,
    ProcessingNavigationIncreaseShipSpeedCommand,
    ProcessingNavigationDecreaseShipSpeedCommand,
    ProcessingNavigationTurnLeftCommand,
    ProcessingNavigationTurnRightCommand,
    ProcessingNavigationRotateToTargetCommand,
    MessageAddedToJournal,
    PreProcessingGenerateNewAsteroidCommand,
    ProcessingGenerateAsteroidCommand,
    ProcessingNavigationStopShipCommand,
    ProcessingNavigationFullSpeedCommand,
    CalculationTurnAvg
}
