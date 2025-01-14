namespace DeepSpaceSaga.UI.Screens.LoadGame;

public partial class LoadGameScreen : Form
{
    public LoadGameScreen()
    {
        InitializeComponent();

        VisibleChanged += Event_ScreenVisibleChanged;
    }

    private void Event_ScreenVisibleChanged(object? sender, EventArgs e)
    {
        if (Visible)
        {
            ReDrawSaves();
        }
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

    private void Event_CloseScreen(object sender, EventArgs e)
    {
        Global.GameManager.Screens.ShowGameMenuScreen();
    }

    private void ReDrawSaves()
    {
        // Clear existing save controls
        Controls.OfType<GameLoadRow>().ToList().ForEach(x => Controls.Remove(x));

        int currentSave = 0;

        foreach (var item in Global.GameManager.SaveLoadSystem.GetAllSaves())
        {
            if (currentSave >= 5) break;

            var saveControl = new GameLoadRow
            {
                LabelText = item,
                Location = new Point(25, 70 * currentSave + 25),
                Visible = true,
            };

            saveControl.OnLoadClicked += Event_Load;
            saveControl.OnDeleteClicked += Event_Delete;

            Controls.Add(saveControl);

            currentSave++;
        }
    }

    private void Event_Delete(object? sender, string saveName)
    {
        Global.GameManager.SaveLoadSystem.DeleteSave(saveName);

        ReDrawSaves();
    }

    private void Event_Load(object? sender, string saveName)
    {
        Global.GameManager.Load(saveName);

        Global.GameManager.Screens.ShowTacticalGameScreen();
    }
}
