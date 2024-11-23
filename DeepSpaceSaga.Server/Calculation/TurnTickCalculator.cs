namespace DeepSpaceSaga.Server.Calculation;

public class TurnTickCalculator
{
    public GameSession Execute(GameSession session, int ticks = 1)
    {
        var processingSession = session.Copy();

        for (var i = 0; i < ticks; i++)
        {
            processingSession = new DataProcessing.Coordinates().Recalculate(processingSession);
        }

        return processingSession;
    }
}
