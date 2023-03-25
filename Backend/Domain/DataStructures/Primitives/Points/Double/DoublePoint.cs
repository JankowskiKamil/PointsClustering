using Backend.Domain.DataStructures.Primitives.Points.Contracts;

namespace Backend.Domain.DataStructures.Primitives.Points.Double;

public class DoublePoint : IPoint<double>
{
    public double X { get; }

    public double Y { get; }

    public DoublePoint(double x, double y)
    {
        X = x;
        Y = y;
    }

}
