namespace DeepSpaceSaga.Tests.Universe.Equipment.Mining;

public class MiningLaserTests
{
    private readonly MiningLaser _sut;

    public MiningLaserTests()
    {
        _sut = new MiningLaser
        {
            Id = 100,
            OwnerId = 1
        };
    }

    [Fact]
    public void Constructor_ShouldSetDefaultCategory()
    {
        // Assert
        _sut.Category.Should().Be(Category.MiningLaser);
    }

    [Fact]
    public void Harvest_ShouldCreateCorrectCommand()
    {
        // Arrange
        int targetObjectId = 42;

        // Act
        var result = _sut.Harvest(targetObjectId);

        // Assert
        result.Should().NotBeNull();
        result.Category.Should().Be(CommandCategory.Mining);
        result.Type.Should().Be(CommandTypes.MiningOperationsHarvest);
        result.CelestialObjectId.Should().Be(_sut.OwnerId);
        result.TargetCelestialObjectId.Should().Be(targetObjectId);
        result.ModuleId.Should().Be(_sut.Id);
    }
}
