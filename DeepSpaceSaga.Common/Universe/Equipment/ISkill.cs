namespace DeepSpaceSaga.Common.Universe.Equipment;

public interface ISkill
{
    int Id { get; set; }
    string ImageFile { get; set; }

    void Execute(int ownerId, int moduleId, int targetId, int targetModuleId);
}
