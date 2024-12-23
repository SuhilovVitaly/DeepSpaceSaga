namespace DeepSpaceSaga.Common.Extensions;

public static class SpacecraftExtensions
{
    public static IModule Module(this ISpacecraft spacecraft, Category category)

    {
        return spacecraft.GetModules(category).FirstOrDefault();
    }
}
