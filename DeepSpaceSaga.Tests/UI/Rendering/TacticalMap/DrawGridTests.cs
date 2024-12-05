using DeepSpaceSaga.Common.Geometry;
using DeepSpaceSaga.UI.Render.Rendering.TacticalMap;

namespace DeepSpaceSaga.Tests.UI.Rendering.TacticalMap;

public class DrawGridTests
{
    [Fact]
    public void GetLeftCorner_CalculateWith1000SizeZoom_ShouldBeCorrect()
    {
        // Arrange
        var zoomSize = 1000;
        var expectedCorner = new SpaceMapPoint(-350, -100);

        IScreenInfo screenInfo = new ScreenParameters(3300, 1800, 10000, 10000, zoomSize);

        // Act
        var corner = DrawGrid.GetLeftCorner(screenInfo);

        // Assert
        Assert.Equal(expectedCorner, corner);
    }

    [Fact]
    public void GetLeftCorner_CalculateWithBigSizeZoom_ShouldBeCorrect()
    {
        // Arrange
        var zoomSize = 1000;
        var expectedCorner = new SpaceMapPoint(-350, -100);

        IScreenInfo screenInfo = new ScreenParameters(3300, 1800, 10000, 10000, zoomSize);

        // Act
        var corner = DrawGrid.GetLeftCorner(screenInfo);

        // Assert
        Assert.Equal(expectedCorner, corner);
    }
}
