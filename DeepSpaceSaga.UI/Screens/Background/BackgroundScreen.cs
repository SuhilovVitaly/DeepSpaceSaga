namespace DeepSpaceSaga.UI.Screens.Background;

public partial class BackgroundScreen : Form
{
    // Add event that will fire only once when form is first shown
    public event EventHandler FirstShown;
    private bool _hasShown;

    public BackgroundScreen()
    {
        InitializeComponent();

        // Set form properties
        FormBorderStyle = FormBorderStyle.None;
        BackColor = Color.Black;
        ShowInTaskbar = false;

        // Set size to primary screen dimensions
        Size = Screen.PrimaryScreen.Bounds.Size;
        Location = new Point(0, 0);

        // Subscribe to the Shown event
        Shown += BackgroundScreen_Shown;
    }

    private void BackgroundScreen_Shown(object sender, EventArgs e)
    {
        if (!_hasShown)
        {
            _hasShown = true;
            FirstShown?.Invoke(this, EventArgs.Empty);
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        // Draw background image centered
        string backgroundPath = Path.Combine("Images", "MainMenuBackground.jpg");
        if (File.Exists(backgroundPath))
        {
            using var backgroundImage = Image.FromFile(backgroundPath);
            int x = Width - backgroundImage.Width; // Right align image
            int y = (Height - backgroundImage.Height) / 2; // Keep vertical centering
            e.Graphics.DrawImage(backgroundImage, x, y);
        }

        // Draw border
        using Pen borderPen = new(UiConstants.FormBorderColor, UiConstants.FormBorderSize);
        Rectangle borderRect = new(
            UiConstants.FormBorderSize / 2,
            UiConstants.FormBorderSize / 2,
            Width - UiConstants.FormBorderSize,
            Height - UiConstants.FormBorderSize
        );
        e.Graphics.DrawRectangle(borderPen, borderRect);
    }

    public void ShowChildForm(Form childForm, bool isTransparent = false)
    {
        if (childForm == null) return;

        // Check if form already exists in controls
        var existingForm = Controls.OfType<Form>().FirstOrDefault(f => f.GetType() == childForm.GetType());
        
        if (!isTransparent)
        {
            // Hide all other forms in non-transparent mode
            foreach (Form form in Controls.OfType<Form>())
            {
                form.Visible = false;
            }
        }
        else
        {
            TransparentPanel overlayPanel = new()
            {
                Size = this.Size,
                Location = new Point(0, 0)
            };

            Controls.Add(overlayPanel);
            overlayPanel.BringToFront();
        }

        if (existingForm != null)
        {
            // Show existing form and bring to front
            existingForm.Visible = true;
            existingForm.BringToFront();
            existingForm.Focus();
            return;
        }

        // Add new form if it doesn't exist
        childForm.TopLevel = false;
        childForm.FormBorderStyle = FormBorderStyle.None;
        childForm.Dock = DockStyle.None;

        // Center child form
        childForm.Location = new Point(
            (Width - childForm.Width) / 2,
            (Height - childForm.Height) / 2
        );


        Controls.Add(childForm);
        childForm.Show();
        childForm.BringToFront();
        childForm.Focus();
    }
}


