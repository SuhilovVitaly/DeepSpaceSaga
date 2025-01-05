namespace DeepSpaceSaga.UI.Screens.MainGameScreen;

public partial class ScreenItemsTransfer : UserControl
{
    public ScreenItemsTransfer()
    {
        InitializeComponent();
    }

    public void ShowTransfer(ISpacecraft spacecraft, int cargoId, int sourceId, GameSession session)
    {

    }

    private void pictureBox13_Click(object sender, EventArgs e)
    {
        Visible = false;
    }
}
