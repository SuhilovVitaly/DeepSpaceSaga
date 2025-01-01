namespace DeepSpaceSaga.Common.Universe.Audit;

public enum EventType
{
    DetectCelestialObject,
    CelestialObjectIdentified,
    NavigationManeuver,
    AsteroidHarvestFinished,
    AsteroidHarvestCancelled,
    AsteroidHarvestShowResults,
    AsteroidHarvestDestroy,
    EventAcknowledgement
}
