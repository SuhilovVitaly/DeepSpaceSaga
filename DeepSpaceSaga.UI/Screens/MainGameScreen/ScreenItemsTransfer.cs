namespace DeepSpaceSaga.UI.Screens.MainGameScreen;

public partial class ScreenItemsTransfer : UserControl
{
    public ScreenItemsTransfer()
    {
        InitializeComponent();
    }

    public void ShowTransfer(ISpacecraft spacecraft, int cargoId, int sourceId, GameSession session)
    {
        var cargo = spacecraft.GetModule(cargoId) as ICargoContainer;

        crlNameTargetCelestialObject.Text = spacecraft.Name;
        crlNameSourceCargoContainer.Text = cargo.Name;
        crlSourceCargoContainerCapacity.Text = $"Capacity ( {cargo.Capacity} / {cargo.MaxCapacity} )";

        cargoContainerTarget.UpdateView(cargo.Items);
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
