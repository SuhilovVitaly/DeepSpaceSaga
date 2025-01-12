namespace DeepSpaceSaga.UI.Screens.MainMenu;

public partial class MainMenuScreen : Form
{
    private const int BORDER_WIDTH = 2;

    public MainMenuScreen()
    {
        InitializeComponent();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        // Draw border
        using Pen borderPen = new Pen(Color.FromArgb(32, 32, 32), BORDER_WIDTH);
        Rectangle borderRect = new(
            BORDER_WIDTH / 2,
            BORDER_WIDTH / 2,
            Width - BORDER_WIDTH,
            Height - BORDER_WIDTH
        );
        e.Graphics.DrawRectangle(borderPen, borderRect);
    }

    private void button1_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        Global.GameManager.ShowTacticalGameScreen();
    }
}
