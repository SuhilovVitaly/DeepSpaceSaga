namespace WinFormsApp1;

internal class ObjectLocation
{
    public float X;
    public float Y;

    public ObjectLocation(float x, float y)
    {
        X = x;
        Y = y;
    }   

    public PointF ToPoint()
    {
        return new PointF(X, Y);
    }
}
