using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace DeepSpaceSaga.Server.Services;

public class SaveLoadService: ISaveLoadService
{
    private readonly string _savesDirectory = "Saves";
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

    public void DeleteSave(string saveFileName)
    {
        var savePath = Path.Combine(_savesDirectory, saveFileName + ".json");

        if (File.Exists(savePath))
        {
            File.Delete(savePath);
        }
    }
}
