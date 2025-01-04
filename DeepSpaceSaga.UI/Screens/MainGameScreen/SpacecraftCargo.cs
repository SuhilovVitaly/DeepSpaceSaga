namespace DeepSpaceSaga.UI.Screens.MainGameScreen;

public partial class SpacecraftCargo : ControlWindow
{
    public SpacecraftCargo()
    {
        InitializeComponent();
        // Subscribe to panel's paint event
        panel1.Paint += Panel1_Paint;

        IsResizible = true;
    }

    public void ShowCargo()
    {
        Invalidate();
    }

    private void Panel1_Paint(object sender, PaintEventArgs e)
    {
        // Create fonts for normal and bold text
        var regularFont = panel1.Font ?? DefaultFont;
        if (regularFont == null)
        {
            throw new InvalidOperationException("Font is not properly initialized.");
        }
        using var boldFont = new Font(regularFont, FontStyle.Bold);

        // Create brushes for different colors
        using var grayBrush = new SolidBrush(Color.DimGray);
        using var whiteBrush = new SolidBrush(Color.White);
        using var greenBrush = new SolidBrush(Color.LimeGreen);

        // Split text into parts
        string prefix = "The space occupied by the cargo is ";
        string currentValue = "100";
        string middle = "from";
        string maxValue = "30.000";

        // Measure string widths
        var prefixSize = e.Graphics.MeasureString(prefix, regularFont);
        var currentValueSize = e.Graphics.MeasureString(currentValue, boldFont);
        var middleSize = e.Graphics.MeasureString(middle, regularFont);
        var maxValueSize = e.Graphics.MeasureString(maxValue, boldFont);

        // Calculate total width and starting X position (right-aligned)
        float totalWidth = prefixSize.Width + currentValueSize.Width + middleSize.Width + maxValueSize.Width;
        float startX = panel1.Width - totalWidth - 10; // 10 pixels padding from right
        float y = 8;

        // Draw each part
        e.Graphics.DrawString(prefix, regularFont, grayBrush, startX, y);
        startX += prefixSize.Width;

        e.Graphics.DrawString(currentValue, boldFont, whiteBrush, startX, y);
        startX += currentValueSize.Width;

        e.Graphics.DrawString(middle, regularFont, grayBrush, startX, y);
        startX += middleSize.Width;

        e.Graphics.DrawString(maxValue, boldFont, greenBrush, startX, y);
    }

    // Remove text drawing from control's OnPaint
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
    }

    private void SpacecraftCargo_Resize(object sender, EventArgs e)
    {
        Invalidate();
    }
}
