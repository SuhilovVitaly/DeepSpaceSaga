using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DeepSpaceSaga.Server.SaveLoadSystem;

public class SaveLoadManager
{
    private readonly string _savesDirectory;
    private static readonly JsonSerializerSettings _jsonSettings = new()
    {
        Formatting = Formatting.Indented,
        TypeNameHandling = TypeNameHandling.Auto,  // For proper interface serialization
        ContractResolver = new DefaultContractResolver
        {
            IgnoreSerializableAttribute = true
        },
        FloatParseHandling = FloatParseHandling.Double,  // Handle floating point numbers correctly
        FloatFormatHandling = FloatFormatHandling.DefaultValue,
        MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead,
        NullValueHandling = NullValueHandling.Include,
        ObjectCreationHandling = ObjectCreationHandling.Replace
    };

    public SaveLoadManager(string savesDirectory = "Saves")
    {
        _savesDirectory = savesDirectory;
        Directory.CreateDirectory(_savesDirectory);
    }

    public async Task Save(IFlowContext context, string saveFileName)
    {
        var savePath = Path.Combine(_savesDirectory, saveFileName);
        
        var saveData = new SaveData
        {
            CelestialMap = context.Session.SpaceMap.Copy()
        };

        foreach (var celestialObject in saveData.CelestialMap)
        {
            var spacecraft = celestialObject as ISpacecraft;

            if (spacecraft != null)
            {
                foreach (var module in spacecraft.Modules)
                {
                    module.Reloading = module.ReloadTime;
                    module.IsActive = false;
                    module.IsCalculated = false;
                    module.TargetId = -1;
                }
            }
        }

        var json = JsonConvert.SerializeObject(saveData, _jsonSettings);
        await File.WriteAllTextAsync(savePath, json);
    }

    public SessionContext Load(string saveFileName)
    {
        var savePath = Path.Combine(_savesDirectory, saveFileName);
        
        try
        {
            if (!File.Exists(savePath))
            {
                throw new FileNotFoundException($"Файл сохранения не найден: {savePath}");
            }

            var json = File.ReadAllText(savePath);
            
            if (string.IsNullOrEmpty(json))
            {
                throw new InvalidDataException($"Файл сохранения пуст: {savePath}");
            }

            var saveData = JsonConvert.DeserializeObject<SaveData>(json, _jsonSettings);
            
            if (saveData == null)
            {
                throw new InvalidDataException($"Не удалось десериализовать данные из файла: {savePath}");
            }

            var metrics = new ServerMetrics();

            foreach (var celestialObject in saveData.CelestialMap)
            {
                var spacecraft = celestialObject as ISpacecraft;

                if (spacecraft != null)
                {
                    foreach (var module in spacecraft.Modules)
                    {
                        module.Reloading = module.ReloadTime;
                        module.IsActive = false;
                        module.IsReloaded = true;
                        module.IsCalculated = false;
                        module.TargetId = -1;
                        module.IsCalculated = true;
                    }
                }
            }

            var session = new SessionContext(
                new GameSession(saveData.CelestialMap, new GameSessionsSettings()),
                new GameEventsSystem(metrics, new GameActionEvents([])),
                metrics,
                new GenerationTool(),
                new LocalGameServerOptions()
            );

            return session;
        }
        catch (Exception ex)
        {
            throw new Exception($"Ошибка при загрузке сохранения '{savePath}': {ex.Message}", ex);
        }
    }
}
