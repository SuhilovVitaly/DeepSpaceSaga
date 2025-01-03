﻿using DeepSpaceSaga.Server;

namespace DeepSpaceSaga.Tests.Server.Session;

public class GameSpeedTests
{
    [Fact]
    public void GameSession_BasicNavigationCalculatorsByFastGameSpeed_ShouldBeCorrect()
    {
        // Arrange
        double expectedStartPositionX = 1000;
        double expectedAfterCalculationPositionX = 1010;

        // Act
        var session = new GameSession(new CelestialMap([]));

        var spacecraft = Generator.SpacecraftWithModules();
        session.SpaceMap.Add(spacecraft);
        session.State.SetSpeed(10);

        var _gameServer = Generator.LocalGameServerWithPreSetSessoin(session);
        
        double startPositionX = spacecraft.PositionX;

        _gameServer.Execution();

        var spacecraftAfterCalculation = _gameServer.GetSession().SpaceMap.GetCelestialObjects()[0] as ISpacecraft;

        double afterCalculationPositionX = spacecraftAfterCalculation.PositionX;

        // Assert
        Assert.Equal(expectedStartPositionX, startPositionX);
        Assert.Equal(expectedAfterCalculationPositionX, afterCalculationPositionX);
    }

    [Fact]
    public void GameSession_ModuleReloadByFastGameSpeed_ShouldBeCorrect()
    {
        // Arrange
        double expectedReloadingAfterCalculation = 10;

        // Act
        var session = new GameSession(new CelestialMap([]));

        var spacecraft = Generator.SpacecraftWithModules();
        var moduleScanner = GeneralModuleGenerator.CreateSpaceScanner(new GenerationTool(), spacecraft.Id, "SCR5001");
        moduleScanner.Id = 100;
        moduleScanner.Reload(1);

        spacecraft.Modules.Add(moduleScanner);

        session.SpaceMap.Add(spacecraft);
        session.State.SetSpeed(10);

        var _gameServer = Generator.LocalGameServerWithPreSetSessoin(session);
        var spacecraftInSession = _gameServer.GetSession().SpaceMap.GetCelestialObjects()[0] as ISpacecraft;

        _gameServer.Execution();

        var spacecraftAfterCalculation = _gameServer.GetSession().SpaceMap.GetCelestialObjects()[0] as ISpacecraft;

        var moduleScannerAfterCalculation = spacecraftAfterCalculation.GetModule(100);

        // Assert
        Assert.Equal(expectedReloadingAfterCalculation, moduleScannerAfterCalculation.Reloading);
    }
}
