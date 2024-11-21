using Newtonsoft.Json;

namespace Deep_Space_Navigation
{
    public static class ExtensionMethods
    {
        public static T DeepClone<T>(this T source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), "Source cannot be null.");
            }

            // Сериализация объекта в JSON и десериализация для глубокого клонирования
            var jsonString = JsonConvert.SerializeObject(source, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto // Включаем хранение информации о типах
            });

            var clonedObject = JsonConvert.DeserializeObject<T>(jsonString, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            })!;

            return clonedObject;
        }
    }
}
