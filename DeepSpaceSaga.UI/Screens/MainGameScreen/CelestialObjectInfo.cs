using System.Windows.Forms;

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

        crlCelestialObjectName.Text = celestialObject.Name;

        lblType.Text = celestialObject.Types.GetDescription();

        lblSize.Text = $"{Math.Round(celestialObject.Size, 2)} mt";

        lblSpeed.Text = $"{Math.Round(celestialObject.Speed, 2)} ms";

        lblDirection.Text = $"{Math.Round(celestialObject.Direction, 2)} °";

        lblDistance.Text = $"{Math.Round(distance, 2)} mt";
    }

    private void ChangeColorsByCelestialObjectType(ICelestialObject celestialObject)
    {
        var color = celestialObject.GetColor();

        crlCelestialObjectName.ForeColor = Color.FromArgb(color.Red, color.Green, color.Blue);   
    }
}
