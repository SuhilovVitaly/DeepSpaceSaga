namespace DeepSpaceSaga.UI.Screens.MainGameScreen;

public partial class ScreenItemsTransfer : UserControl
{
    private ICelestialObject _targetObject;
    private ICargoContainer _targetContainer;
    private ISpacecraft _spacecraft;
    private int _cargoId;
    private int _sourceId;
    private GameSessionDTO _gameSession;
    private List<ICommand> _commands;

    public ScreenItemsTransfer()
    {
        InitializeComponent();
    }
    public void ShowTransfer(ISpacecraft spacecraft, int cargoId, int sourceId, GameSessionDTO session, ICelestialObject targetObject, ICargoContainer targetContainer)
    {
        _commands = new List<ICommand>();        

        RefreshTransfer(spacecraft, cargoId, sourceId, session, targetObject, targetContainer);
    }

    private void RefreshTransfer(ISpacecraft spacecraft, int cargoId, int sourceId, GameSessionDTO session, ICelestialObject targetObject, ICargoContainer targetContainer)
    {
        cargoContainerSource.OnItemClick -= Event_SelectItem;

        _targetContainer = targetContainer;
        _spacecraft = spacecraft;
        _cargoId = cargoId;
        _sourceId = sourceId;
        _gameSession = session;
        _targetObject = targetObject;

        var cargo = spacecraft.GetModule(cargoId) as ICargoContainer;

        crlNameTargetCelestialObject.Text = spacecraft.Name;
        crlNameSourceCelestialObject.Text = targetObject.Name;

        crlNameSourceCargoContainer.Text = cargo.Name;
        crlSourceCargoContainerCapacity.Text = $"Capacity ( {cargo.Capacity} / {cargo.MaxCapacity} )";

        cargoContainerTarget.UpdateView(cargo.Items);
        cargoContainerSource.UpdateView(targetContainer.Items, true);
        cargoContainerSource.OnItemClick += Event_SelectItem;

        pictureBox3.Image = ImageLoader.LoadLayersTacticalImage("asteroid");
        pictureBox4.Image = ImageLoader.LoadLayersTacticalImage("spacecraft");
    }

    private void Event_SelectItem(ICoreItem item)
    {
        var cargo = _spacecraft.GetModule(_cargoId) as ICargoContainer;

        _targetContainer.RemoveItem(item);
        cargo.AddItem(item);

        _commands.Add(GenerateCommand(_spacecraft, _targetObject.Id, _targetContainer.Id, item.Id));

        RefreshTransfer(_spacecraft, _cargoId, _sourceId, _gameSession, _targetObject, _targetContainer);
    }

    private void Event_CloseScreenAndSendCommands(object sender, EventArgs e)
    {
        foreach (var command in _commands)
        {
            _ = Global.GameManager.ExecuteCommandAsync(command);
        }

        Visible = false;

        if (Global.GameManager.GetSession().State.IsPaused)
        {
            Global.GameManager.Events.Resume();
        }
    }

    private ICommand GenerateCommand(ISpacecraft spacecraft, int inputObjectId, int inputModuleId, int inputItemId)
    {
        return new CargoOperationsCommand
        {
            Category = CommandCategory.CargoOperations,
            Type = CommandTypes.CargoOperationsTransfer,
            IsOneTimeCommand = true,
            TargetCelestialObjectId = inputObjectId,
            CelestialObjectId = spacecraft.Id,
            ModuleId = spacecraft.Module(Common.Universe.Equipment.Category.CargoUnit).Id,
            InputItemId = inputItemId,
            InputModuleId = inputModuleId,
            IsUnique = false
        };
    }
}
