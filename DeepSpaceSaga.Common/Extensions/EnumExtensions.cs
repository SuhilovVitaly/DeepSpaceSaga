namespace DeepSpaceSaga.Common.Extensions;

public static class EnumExtensions
{
    public static string GetDescription(this Enum value)
    {
        var fieldInfo = value.GetType().GetField(value.ToString());
        var attributes = fieldInfo?.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
        return attributes?.Length > 0 ? attributes[0].Description : value.ToString();
    }
}
