namespace DeepSpaceSaga.UI.Screens.MainGameScreen;

public partial class ItemsContainer : ControlWindow
{
    public ItemsContainer()
    {
        InitializeComponent();

        IsResizible = false;
        IsDraggible = false;

        crlCloseButton.Click += Event_Close;
    }

    private void Event_Close(object? sender, EventArgs e)
    {
        if(Global.GameManager.GetSession().State.IsPaused)
        {
            Global.GameManager.EventController.Resume();
        }
    }

    public void ShowContainer(GameActionEvent gameEvent, GameSession session)
    {
        if(gameEvent is null) return;
        
        var sourceCelestialObject = session.GetCelestialObject((long)gameEvent.CelestialObjectId);
        var oreContainer = session.GetCelestialObject((long)gameEvent.TargetObjectId) as Common.Universe.Entities.CelestialObjects.Containers.IContainer;

        if (oreContainer is null) return;

        var currentItemNumber = 0;

        foreach (var item in oreContainer.Items)
        {
            currentItemNumber++;
            ShowItem(currentItemNumber, item);
        }
    }

    private void ShowItem(int currentItemNumber, ICoreItem item)
    {
        var imagePath = Path.Combine("Images", item.Image.Replace(".", "/") + ".png");
        
        switch (currentItemNumber)
        {
            case 1:
                using (var newImage = Image.FromFile(imagePath))
                {
                    pictureBox1.Image?.Dispose();
                    pictureBox1.Image = newImage.Clone() as Image;
                }
                pictureBox1.Visible = true;
                label1.Text = item.Volume.ToString();
                label1.Visible = true;
                break;
            case 2:
                // TODO: Implement case 2 or remove if not needed
                break;
            default:
                // Consider handling unexpected item numbers
                throw new ArgumentException($"Unexpected item number: {currentItemNumber}");
        }
    }
}
