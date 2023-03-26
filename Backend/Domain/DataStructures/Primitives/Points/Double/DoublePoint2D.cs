using Backend.Domain.DataStructures.Primitives.Points.Contracts;

namespace Backend.Domain.DataStructures.Primitives.Points.Double;

public class DoublePoint2D : IPoint2D<double>
{
    public double X { get; }

    public double Y { get; }

    public DoublePoint2D(double x, double y)
    {
        X = x;
        Y = y;
    }

    public DoublePoint2D Clone() => new(X, Y);

    public override string ToString()
    {
        return $"[{X}, {Y}]";
    }

}
