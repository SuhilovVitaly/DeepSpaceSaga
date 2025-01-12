namespace DeepSpaceSaga.UI.Screens.SaveGame;

public partial class SaveGameScreen : Form
{
    public SaveGameScreen()
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
        Global.GameManager.ShowGameMenuScreen();
    }
}
