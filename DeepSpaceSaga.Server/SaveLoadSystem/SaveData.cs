namespace DeepSpaceSaga.Server.SaveLoadSystem;

[Serializable]
internal class SaveData
{
    [JsonProperty]
    public CelestialMap CelestialMap { get; set; }
}
