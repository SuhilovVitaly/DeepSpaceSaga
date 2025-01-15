namespace DeepSpaceSaga.Server.SaveLoadSystem;

public class SaveLoadManager : ISaveLoadManager
{
    private static readonly ILog Logger = LogManager.GetLogger(typeof(SaveLoadManager));

    private readonly string _savesDirectory;
    private static readonly JsonSerializerSettings _jsonSettings = new()
    {
        Formatting = Formatting.Indented,
        TypeNameHandling = TypeNameHandling.Auto,
        ContractResolver = new DefaultContractResolver
        {
            IgnoreSerializableAttribute = true
        },
        FloatParseHandling = FloatParseHandling.Double,
        FloatFormatHandling = FloatFormatHandling.DefaultValue,
        MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead,
        NullValueHandling = NullValueHandling.Include,
        ObjectCreationHandling = ObjectCreationHandling.Replace,
        PreserveReferencesHandling = PreserveReferencesHandling.Objects,
        ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
        TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
        SerializationBinder = new DefaultSerializationBinder()
    };

    public SaveLoadManager(string savesDirectory = "Saves")
    {
        _savesDirectory = savesDirectory;
        Directory.CreateDirectory(_savesDirectory);
    }

    public void  DeleteSave(string saveFileName)
    {
        var savePath = Path.Combine(_savesDirectory, saveFileName + ".json");

        if (File.Exists(savePath))
        {
            File.Delete(savePath);
        }
    }

    public async Task Save(CelestialMap spaceMap, string saveFileName)
    {
        var savePath = Path.Combine(_savesDirectory, saveFileName);
        
        var saveData = new SaveData
        {
            CelestialMap = spaceMap.Copy()
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

    public List<string> GetAllSaves()
    {
        var result = new List<string>();

        var files = Directory.GetFiles(_savesDirectory)
            .OrderByDescending(f => File.GetLastWriteTime(f))
            .ToList();

        foreach (var file in files)
        {
            result.Add(Path.GetFileName(file).Replace(".json", ""));
        }

        return result;
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

            Logger.Info($"Loading save file: {saveFileName}");
            
            var saveData = JsonConvert.DeserializeObject<SaveData>(json, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                ObjectCreationHandling = ObjectCreationHandling.Replace,
                FloatParseHandling = FloatParseHandling.Double,
                MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead,
                SerializationBinder = new DefaultSerializationBinder(),
                Error = (sender, args) =>
                {
                    Logger.Error($"Deserialization error: {args.ErrorContext.Error.Message}");
                    Logger.Error($"Member: {args.ErrorContext.Member}");
                    Logger.Error($"Path: {args.ErrorContext.Path}");
                    args.ErrorContext.Handled = true;
                }
            });
            
            if (saveData == null)
            {
                throw new InvalidDataException($"Не удалось десериализовать данные из файла: {savePath}");
            }

            // Debug logging
            foreach (var celestialObject in saveData.CelestialMap)
            {
                var spacecraft = celestialObject as ISpacecraft;
                if (spacecraft != null)
                {
                    foreach (var module in spacecraft.Modules)
                    {
                        if (module is CargoContainer container)
                        {
                            Logger.Debug($"Container ID: {container.Id}");
                            Logger.Debug($"Items count: {container.Items?.Count ?? 0}");
                            if (container.Items != null)
                            {
                                foreach (var item in container.Items)
                                {
                                    Logger.Debug($"Item: {item?.GetType()?.FullName}, ID: {item?.Id}");
                                }
                            }
                        }
                    }
                }
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
        catch (JsonSerializationException ex)
        {
            Logger.Error($"JSON deserialization error: {ex.Message}");
            Logger.Error($"Path: {ex.Path}");
            throw;
        }
        catch (Exception ex)
        {
            Logger.Error($"Failed to load save file: {ex}");
            throw;
        }
    }
}
