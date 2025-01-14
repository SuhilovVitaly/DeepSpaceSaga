namespace DeepSpaceSaga.UI.Screens.MainMenu;

public partial class GameMenuScreen : Form
{
    public GameMenuScreen()
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

    private void button1_Click(object sender, EventArgs e)
    {
        Global.GameManager.Screens.ShowMenuScreen();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        Global.GameManager.Screens.ShowTacticalGameScreen();
    }

    private void button3_Click(object sender, EventArgs e)
    {
        Global.GameManager.QuickLoad();
    }

    private void Event_SaveGame(object sender, EventArgs e)
    {
        Global.GameManager.Screens.ShowSaveGameScreen();
    }

    private void Event_LoadGame(object sender, EventArgs e)
    {
        Global.GameManager.Screens.ShowLoadGameScreen();
    }
}
