namespace DeepSpaceSaga.Server.Calculation.DataProcessing;

internal class ScanProcessing
{
    public void Execute(GameSession session, Command command)
    {
        var currentCelestialObject = session.GetCelestialObject(command.CelestialObjectId);

        switch (command.Type)
        {
            case CommandTypes.PreScanCelestialObject:
                PreScanCelestialObject(currentCelestialObject, command);
                break;

            case CommandTypes.PreScanCelestialObjectFinished:
                PreScanCelestialObjectFinished(session, currentCelestialObject, command);
                break;
        }

        AddToJournal(session, command, currentCelestialObject);
    }

    private void PreScanCelestialObjectFinished(GameSession session, ICelestialObject celestialObject, Command command)
    {
        var spacecraft = celestialObject.ToSpaceship();
        var target = session.GetCelestialObject(command.TargetCelestialObjectId);

        target.IsPreScanned = true;

        var module = spacecraft.GetModule(command.ModuleId);
        module.IsCalculated = true;
    }

    private void PreScanCelestialObject(ICelestialObject celestialObject, Command command)
    {
        var spacecraft = celestialObject.ToSpaceship();

        var module = spacecraft.GetModule(command.ModuleId);
        module.TargetId = command.TargetCelestialObjectId;        
        module.Reload();
    }

    private void AddToJournal(GameSession session, Command command, ICelestialObject celestialObject)
    {
        session.Logbook.Add(
            new Common.Universe.Audit.EventMessage
            {
                Id = IdGenerator.GetNextId(),
                Type = Common.Universe.Audit.EventType.DetectCelestialObject,
                Text = "Scan: " + command.Type.GetDescription() 
            });
    }
}
