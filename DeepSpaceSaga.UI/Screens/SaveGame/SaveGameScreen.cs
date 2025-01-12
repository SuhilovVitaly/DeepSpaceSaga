namespace DeepSpaceSaga.UI.Screens.SaveGame;

public partial class SaveGameScreen : Form
{
    public SaveGameScreen()
    {
        InitializeComponent();

        VisibleChanged += SaveGameScreen_VisibleChanged;
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

    private void SaveGameScreen_VisibleChanged(object sender, EventArgs e)
    {
        if (this.Visible)
        {
            // Clear existing save controls
            Controls.OfType<GameLabelRow>().ToList().ForEach(x => Controls.Remove(x));

            int currentSave = 0;

            foreach (var item in Global.GameManager.SaveLoadSystem.GetAllSaves())
            {                
                if (currentSave >= 5) break;

                var saveControl = new GameLabelRow
                {
                    LabelText = item,
                    Location = new Point(25, 70 * currentSave + 25),
                    Visible = true,
                };

                Controls.Add(saveControl);

                currentSave++;
            }
        }
    }
}
