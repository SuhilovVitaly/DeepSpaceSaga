namespace DeepSpaceSaga.UI.Screens.Background;

public partial class BackgroundScreen : Form
{
    private const int BORDER_WIDTH = 2;

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
        this.Shown += BackgroundScreen_Shown;
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

        // Draw border
        using Pen borderPen = new Pen(Color.FromArgb(12, 12, 12), BORDER_WIDTH);
        Rectangle borderRect = new(
            BORDER_WIDTH / 2,
            BORDER_WIDTH / 2,
            Width - BORDER_WIDTH,
            Height - BORDER_WIDTH
        );
        e.Graphics.DrawRectangle(borderPen, borderRect);
    }

    public void ShowChildForm(Form childForm)
    {
        if (childForm == null) return;

        // Check if form already exists in controls
        var existingForm = Controls.OfType<Form>().FirstOrDefault(f => f.GetType() == childForm.GetType());
        
        // Hide all other forms
        foreach (Form form in Controls.OfType<Form>())
        {
            form.Visible = false;
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
