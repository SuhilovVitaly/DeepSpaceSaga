namespace DeepSpaceSaga.Server;

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
    ProcessingNavigationFullSpeedCommand
}
