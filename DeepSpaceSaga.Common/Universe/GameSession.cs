﻿using DeepSpaceSaga.Common.Layers;

namespace DeepSpaceSaga.Universe;

public class GameSession
{
    public GameSession(CelestialMap spaceMap)
    {
        SpaceMap = spaceMap;
        Settings = new GameSessionsSettings();
        Speed = new GameSpeed();
    }

    public GameSession(CelestialMap spaceMap, GameSessionsSettings settings)
    {
        SpaceMap = spaceMap;
        Settings = settings;
        Speed = new GameSpeed();
    }

    public int Id { get; set; }

    public bool IsRunning { get; set; } = false;

    public int Turn { get; set; } = 1;

    public int TurnTick { get; set; } = 0;

    public CelestialMap SpaceMap { get; internal set; }

    public Journal Logbook { get; internal set; } = new Journal(new List<EventMessage>());

    public GameSessionsSettings Settings { get; set; }

    public GameSpeed Speed { get; set; }
}
