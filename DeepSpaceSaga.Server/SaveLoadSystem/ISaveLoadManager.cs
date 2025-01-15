namespace DeepSpaceSaga.Server.SaveLoadSystem;

public interface ISaveLoadManager
{
    void DeleteSave(string saveFileName);
    Task Save(CelestialMap spaceMap, string saveFileName);
    List<string> GetAllSaves();
    SessionContext Load(string saveFileName);
}
