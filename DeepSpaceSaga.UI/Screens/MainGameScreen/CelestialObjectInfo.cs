
namespace DeepSpaceSaga.UI.Screens.MainGameScreen;

public partial class CelestialObjectInfo : UserControl
{
    public CelestialObjectInfo()
    {
        InitializeComponent();
    }

    public void RefreshInfo(ICelestialObject celestialObject)
    {
        CrossThreadExtensions.PerformSafely(this, RereshControls, celestialObject);
    }

    private void RereshControls(ICelestialObject celestialObject)
    {
        ChangeColorsByCelestialObjectType(celestialObject);

        crlCelestialObjectName.Text = celestialObject.Name;
    }

    private void ChangeColorsByCelestialObjectType(ICelestialObject celestialObject)
    {
        var color = celestialObject.GetColor();

        crlCelestialObjectName.ForeColor = Color.FromArgb(color.Red, color.Green, color.Blue);   
    }
}
