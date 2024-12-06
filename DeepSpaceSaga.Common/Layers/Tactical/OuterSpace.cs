namespace DeepSpaceSaga.Common.Layers.Tactical;

public class OuterSpace
{
    public int ActiveObjectId { get; private set; }
    public int SelectedObjectId { get; private set; }

    public void EventController_OnSelectCelestialObject(ICelestialObject celestialObject)
    {
        SelectedObjectId = celestialObject.Id;
    }

    public void EventController_OnShowCelestialObject(ICelestialObject celestialObject)
    {
        ActiveObjectId = celestialObject.Id;
    }

    public void EventController_OnHideCelestialObject(ICelestialObject celestialObject)
    {
        ActiveObjectId = 0;
    }
}
