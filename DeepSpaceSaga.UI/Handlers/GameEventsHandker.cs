namespace DeepSpaceSaga.UI.Handlers;

public static class GameEventsHandker
{
    public static void Execute(GameSession session, Form1 form1)
    {
        foreach (var gameEvent in session.Events.Where(x=>x.PresentationTurnId == 0))
        {
            switch (gameEvent.TriggerCommand.Type)
            {
                case CommandTypes.MoveForward:
                    break;
                case CommandTypes.TurnLeft:
                    break;
                case CommandTypes.TurnRight:
                    break;
                case CommandTypes.RotateToTarget:
                    break;
                case CommandTypes.DecreaseShipSpeed:
                    break;
                case CommandTypes.IncreaseShipSpeed:
                    break;
                case CommandTypes.SyncSpeedWithTarget:
                    break;
                case CommandTypes.SyncDirectionWithTarget:
                    break;
                case CommandTypes.StopShip:
                    break;
                case CommandTypes.FullSpeed:
                    break;
                case CommandTypes.Acceleration:
                    break;
                case CommandTypes.Fire:
                    break;
                case CommandTypes.AlignTo:
                    break;
                case CommandTypes.Orbit:
                    break;
                case CommandTypes.Explosion:
                    break;
                case CommandTypes.ReloadWeapon:
                    break;
                case CommandTypes.Scanning:
                    break;
                case CommandTypes.Shot:
                    break;
                case CommandTypes.PreScanCelestialObject:
                    break;
                case CommandTypes.PreScanCelestialObjectFinished:
                    break;
                case CommandTypes.GenerateAsteroid:
                    break;
                case CommandTypes.MiningOperationsHarvest:
                    break;
                case CommandTypes.MiningOperationsResult:
                    form1.OpenCargoUI(gameEvent.Copy());
                    break;
                case CommandTypes.MiningOperationsDestroyAsteroid:
                    break;
                case CommandTypes.CargoOperationsShow:
                    break;

            }
        }
    }
}
