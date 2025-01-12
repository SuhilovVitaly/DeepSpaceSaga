namespace DeepSpaceSaga.UI.Screens.SaveGame.ScreenControls;

public partial class GameNewLabelRow : UserControl
{
    public GameNewLabelRow()
    {
        InitializeComponent();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        // Draw border
        using Pen borderPen = new Pen(UiConstants.FormBorderColor, UiConstants.FormBorderSize);
        Rectangle borderRect = new(
            UiConstants.FormBorderSize / 2,
            UiConstants.FormBorderSize / 2,
            Width - UiConstants.FormBorderSize,
            Height - UiConstants.FormBorderSize
        );
        e.Graphics.DrawRectangle(borderPen, borderRect);
    }

    private void Event_SaveGame(object sender, EventArgs e)
    {        
        Global.GameManager.SaveLoadSystem.Save(Global.GameManager.GetSession().SpaceMap, txtSaveName.Text + ".json");
        Global.GameManager.ShowGameMenuScreen();
    }
}
