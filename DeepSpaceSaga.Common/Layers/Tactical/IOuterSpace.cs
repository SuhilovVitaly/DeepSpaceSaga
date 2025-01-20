namespace DeepSpaceSaga.Common.Layers.Tactical;

public interface IOuterSpace
{
    int ActiveObjectId { get; }
    int SelectedObjectId { get; }
    void EventController_OnSelectCelestialObject(ICelestialObject celestialObject);
    void EventController_OnShowCelestialObject(ICelestialObject celestialObject);
    void EventController_OnHideCelestialObject(ICelestialObject celestialObject);
    void EventController_OnUnselectCelestialObject(ICelestialObject @object);
    void CleanActiveObject();
    void CleanSelectedObject();
}
