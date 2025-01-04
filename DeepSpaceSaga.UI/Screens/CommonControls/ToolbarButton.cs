namespace DeepSpaceSaga.UI.Screens.CommonControls
{
    public partial class ToolbarButton : UserControl
    {
        private string _defaultImagePath = @"Images/Toolbar/Cargo.png";
        private string _selectedImagePath = @"Images/Toolbar/CargoSelected.png";
        private Image _defaultImage;
        private Image _selectedImage;

        // Add event handler delegate
        public event EventHandler Click;

        public ToolbarButton()
        {
            InitializeComponent();
            
            if (!DesignMode)
            {
                LoadImages();
                
                // Set default image
                BackgroundImage = _defaultImage;
                BackgroundImageLayout = ImageLayout.Center;
                
                // Subscribe to mouse events
                this.MouseEnter += ToolbarButton_MouseEnter;
                this.MouseLeave += ToolbarButton_MouseLeave;
                this.MouseClick += ToolbarButton_MouseClick;
            }
        }

        private void LoadImages()
        {
            try
            {
                _defaultImage = Image.FromFile(_defaultImagePath);
                _selectedImage = Image.FromFile(_selectedImagePath);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading images: {ex.Message}");
            }
        }

        private void ToolbarButton_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            BackgroundImage = _selectedImage;
        }

        private void ToolbarButton_MouseLeave(object sender, EventArgs e)
        {
            BackgroundImage = _defaultImage;
        }

        private void ToolbarButton_MouseClick(object sender, MouseEventArgs e)
        {
            // Raise Click event
            Click?.Invoke(this, EventArgs.Empty);
        }
    }
}
