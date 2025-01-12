namespace DeepSpaceSaga.UI.Screens.SaveGame.ScreenControls;

public partial class GameLabelRow : UserControl
{
    public string LabelText
    {
        get => label1.Text; // Get the current text of label1
        set => label1.Text = value; // Set the text of label1
    }
    
    public GameLabelRow()
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
}
