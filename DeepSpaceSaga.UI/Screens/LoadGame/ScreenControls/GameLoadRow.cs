namespace DeepSpaceSaga.UI.Screens.LoadGame.ScreenControls;

public partial class GameLoadRow : UserControl
{
    public string LabelText
    {
        get => label1.Text; // Get the current text of label1
        set => label1.Text = value; // Set the text of label1
    }

    // Define events
    public event EventHandler<string>? OnLoadClicked;
    public event EventHandler<string>? OnDeleteClicked;

    public GameLoadRow()
    {
        InitializeComponent();

        cmdLoadGame.Click += (s, e) => OnLoadClicked?.Invoke(this, label1.Text);
        cmdDelete.Click += (s, e) => OnDeleteClicked?.Invoke(this, label1.Text);
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
}
