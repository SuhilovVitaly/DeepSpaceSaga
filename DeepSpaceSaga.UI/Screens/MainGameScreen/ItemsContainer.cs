using DeepSpaceSaga.Common.Universe.Items;

namespace DeepSpaceSaga.UI.Screens.MainGameScreen;

public partial class ItemsContainer : ControlWindow
{
    public ItemsContainer(GameActionEvent gameEvent, GameSession session)
    {
        InitializeComponent();
        IsResizible = false;
        IsDraggible = false;

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
        var image = "Images/" + item.Image.Replace(".", "/") + ".png";

        switch (currentItemNumber)
        {
            case 1:
                pictureBox1.Image = Image.FromFile(image);
                pictureBox1.Visible = true;
                label1.Text = item.Volume.ToString();
                label1.Visible = true;
                break;
            case 2:
                break;
        }
    }
}
