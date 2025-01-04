namespace DeepSpaceSaga.Common.Universe.Equipment;

public abstract class AbstractModule : AbstractItem
{
    public long TargetId { get; set; }
    public bool IsAutoRun { get; set; } = false;
    public bool IsCalculated { get; set; } = true;
    public int Compartment { get; set; }
    public bool IsActive { get; set; }
    public int Slot { get; set; }
    public double ReloadTime { get; set; }
    public int LastReloadTurn { get; set; }
    public double Reloading { get; set; } 
    public bool IsReloaded { get; set; } 

    private static readonly ILog _log = LogManager.GetLogger(typeof(AbstractModule));

    public void Execute() 
    {
        _log.Info($"Module [{Id}][{Name}] Started execution");
        IsCalculated = false;
        Reloading = 0;
        IsReloaded = false;
    }

    public void Reload(double progress, int turn = 0)
    {
        Reloading += progress;

        if(Reloading >= ReloadTime)
        {
            _log.Info($"Module [{Id}][{Name}] Finish execution");
            LastReloadTurn = turn;
            IsReloaded = true;
        }
    }
}
