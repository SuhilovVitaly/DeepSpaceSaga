namespace DeepSpaceSaga.UI.Screens.MainGameScreen;

public partial class CargoItem : UserControl
{
    private Image _image;
    public ICoreItem CoreItem { get; set; }

    public CargoItem()
    {
        InitializeComponent();
        this.Paint += CargoItem_Paint;
    }

    public Image Image
    {
        get { return _image; }
        set
        {
            _image = value;
            this.Invalidate(); // Trigger a repaint
        }
    }

    private void CargoItem_Paint(object sender, PaintEventArgs e)
    {
        if (_image != null)
        {
            // Calculate the center position
            int x = (this.Width - _image.Width) / 2;
            int y = (this.Height - _image.Height) / 2;

            // Draw the image
            e.Graphics.DrawImage(_image, x, y);
        }

        using (Font font = new Font("Arial", 10, FontStyle.Bold))
        {
            string text = CoreItem.Volume + "";
            SizeF textSize = e.Graphics.MeasureString(text, font);
            float textX = (this.Width - textSize.Width) / 2;
            float textY = (this.Height - textSize.Height) ;

            // Draw the gray background
            using (Brush backgroundBrush = new SolidBrush(Color.Black))
            {
                e.Graphics.FillRectangle(backgroundBrush, textX, textY, textSize.Width, textSize.Height - 2);
            }

            // Draw the text
            using (Brush textBrush = new SolidBrush(Color.WhiteSmoke))
            {
                e.Graphics.DrawString(text, font, textBrush, textX, textY);
            }
        }
    }
}
