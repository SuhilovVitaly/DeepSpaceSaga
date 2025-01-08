namespace DeepSpaceSaga.UI.Screens.MainGameScreen;

public partial class CargoContainer : UserControl
{
    public event Action<ICoreItem>? OnItemClick;

    public CargoContainer()
    {
        InitializeComponent();
    }

    private void ClearControls()
    {
        // Unsubscribe from events and dispose controls
        foreach (Control control in Controls)
        {
            if (control is CargoItem cargoItem)
            {
                cargoItem.Click -= (sender, e) => CargoItemClickEvent(cargoItem.CoreItem);
                cargoItem.Dispose();
            }
        }
        Controls.Clear();
    }

    public void UpdateView(List<ICoreItem> items, bool isMovebleItems = false)
    {
        ClearControls();

        var leftMargin = 3;
        var toptMargin = 3;
        var itemWidth = 64;
        var itemHeight = 64;
        var maxRowSize = 5;

        var currentRow = 0;
        var currentCell = 0;

        foreach (var item in items)
        {
            var location = new Point(leftMargin + currentRow * leftMargin + currentRow * itemWidth, toptMargin + currentCell * toptMargin + currentCell * itemHeight);
            var image = "Images/" + item.Image.Replace(".", "/") + ".png";

            var newItem = new CargoItem
            {
                CoreItem = item.Copy(),
                Location = location,
                Visible = true,
                Image = Image.FromFile(image),
                BackColor = Color.Black,
                BorderStyle = BorderStyle.FixedSingle,
            };

            newItem.Click += (sender, e) => CargoItemClickEvent(newItem.CoreItem);

            currentRow++;

            if (currentRow >= maxRowSize)
            {
                currentRow = 0;
                currentCell++;
            }

            newItem.Invalidate();

            Controls.Add(newItem);
        }

        Invalidate();
    }

    private void CargoItemClickEvent(ICoreItem item)
    {
        OnItemClick?.Invoke(item);
    }

    private void CargoContainer_Paint(object sender, PaintEventArgs e)
    {
        var leftMargin = 3;
        var toptMargin = 3;
        var itemWidth = 64;
        var itemHeight = 64;
        var maxRowSize = 5;

        var currentRow = 0;
        var currentCell = 0;

        for( var i = 0; i <= maxRowSize * 10; i++ )
        {
            var location = new Point(leftMargin + currentRow * leftMargin + currentRow * itemWidth, toptMargin + currentCell * toptMargin + currentCell * itemHeight);

            e.Graphics.DrawRectangle(new Pen(Color.DimGray,1), location.X, location.Y, itemWidth, itemHeight - 2);

            currentRow++;

            if (currentRow >= maxRowSize)
            {
                currentRow = 0;
                currentCell++;
            }
        }
    }
}
