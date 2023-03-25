using Backend.Domain.DataStructures.Primitives.Points.Double;

namespace Backend.Domain.DataStructures.Primitives;

public class DoublePointEqualityComparer : IEqualityComparer<DoublePoint2D>
{

    private readonly double _coordinatesTolerance;

    public DoublePointEqualityComparer(double coordinatesTolerance = 0.0001)
    {
        _coordinatesTolerance = coordinatesTolerance;
    }

    public bool Equals(DoublePoint2D? x, DoublePoint2D? y)
    {
        if (x == null && y == null)
            return true;
        else if (x == null || y == null)
            return false;
        else if (Math.Abs(x.X - y.X) <= _coordinatesTolerance && Math.Abs(x.Y - y.Y) <= _coordinatesTolerance)
            return true;
        else
            return false;
    }

    public int GetHashCode(DoublePoint2D obj)
    {
        return HashCode.Combine(obj.X, obj.Y);
    }
}
