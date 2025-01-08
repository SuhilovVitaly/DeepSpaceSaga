namespace DeepSpaceSaga.UI.Screens.MainGameScreen;

public partial class ScreenItemsTransfer : UserControl
{
    private ICelestialObject _targetObject;
    private ICargoContainer _targetContainer;
    private ISpacecraft _spacecraft;
    private int _cargoId;
    private int _sourceId;
    private GameSession _gameSession;

    public ScreenItemsTransfer()
    {
        InitializeComponent();
    }

    public void ShowTransfer(ISpacecraft spacecraft, int cargoId, int sourceId, GameSession session, ICelestialObject targetObject, ICargoContainer targetContainer)
    {
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

        ShowTransfer(_spacecraft, _cargoId, _sourceId, _gameSession, _targetObject, _targetContainer);
    }

    private void pictureBox13_Click(object sender, EventArgs e)
    {
        Visible = false;

        if (Global.GameManager.GetSession().State.IsPaused)
        {
            Global.GameManager.EventController.Resume();
        }
    }

    private void pictureBox11_Click(object sender, EventArgs e)
    {

    }
}
