namespace DeepSpaceSaga.UI.Screens.MainGameScreen;

public partial class CelestialObjectInfo : UserControl
{
    public CelestialObjectInfo()
    {
        InitializeComponent();

        RereshControlsInModeObjectNotSelected();
    }

    public void RefreshInfo(ICelestialObject celestialObject)
    {
        CrossThreadExtensions.PerformSafely(this, RereshControls, celestialObject);
    }

    private void RereshControls(ICelestialObject celestialObject)
    {
        if(celestialObject == null)
        {
            RereshControlsInModeObjectNotSelected();
            return;
        }

        ChangeColorsByCelestialObjectType(celestialObject);

        var spacecraft = Global.GameManager.GetPlayerSpacecraft();
        var distance = GeometryTools.Distance(spacecraft.GetLocation(), celestialObject.GetLocation());

        if(celestialObject.OwnerId == 1)
        {
            imageCelestialObject.Image = ImageLoader.LoadLayersTacticalImage("spacecraft");
        }

        if (celestialObject.Types == CelestialObjectTypes.Asteroid)
        {
            imageCelestialObject.Image = ImageLoader.LoadLayersTacticalImage("asteroid");
        }

        if (celestialObject.Types == CelestialObjectTypes.Container)
        {
            imageCelestialObject.Image = ImageLoader.LoadLayersTacticalImage("container");
        }

        crlCelestialObjectName.Text = celestialObject.Name;

        lblType.Text = celestialObject.Types.GetDescription();

        lblSize.Text = $"{Math.Round(celestialObject.Size, 2)} mt";

        lblSpeed.Text = $"{Math.Round(celestialObject.Speed, 2)} ms";

        lblDirection.Text = $"{Math.Round(celestialObject.Direction, 2)} °";

        lblDistance.Text = $"{Math.Round(distance, 2)} mt";

    }

    private void RereshControlsInModeObjectNotSelected()
    {
        imageCelestialObject.Image = null;
        crlCelestialObjectName.ForeColor = Color.DimGray;
        crlCelestialObjectName.Text = "TARGET IS NOT SELECTED";
        lblType.Text = "";
        lblSize.Text = "";
        lblSpeed.Text = "";
        lblDirection.Text = "";
        lblDistance.Text = "";
    }

    private void ChangeColorsByCelestialObjectType(ICelestialObject celestialObject)
    {
        var color = celestialObject.GetColor();

        crlCelestialObjectName.ForeColor = Color.FromArgb(color.Red, color.Green, color.Blue);   
    }
}
