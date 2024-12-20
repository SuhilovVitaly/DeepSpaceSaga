namespace DeepSpaceSaga.Common.Universe.Equipment;

public abstract class AbstractModule : AbstractItem
{
    public long TargetId { get; set; }
    public bool IsAutoRun { get; set; } = false;
    public bool IsCalculated { get; set; } = true;
    public int Compartment { get; set; }
    public int Slot { get; set; }
    public double ReloadTime { get; set; }
    public double Reloading { get; set; } 
    public bool IsReloaded => Reloading >= ReloadTime;
    public List<ISkill> Skills { get; set; } = new List<ISkill>();

    public void AddSkill(ISkill skill)
    {
        Skills.Add(skill);
    }

    public dynamic CreateServerCommand()
    {
        dynamic serverCommand = new JObject();

        serverCommand.ModuleId = Id;
        serverCommand.Date = DateTime.Now;
        serverCommand.OwnerId = OwnerId;

        return serverCommand;
    }

    public void Reload()
    {
        if (IsReloaded)
        {
            IsCalculated = false;
            Reloading = 0;
        }
        else
        {
            Reloading += 1;
        }
    }
}
