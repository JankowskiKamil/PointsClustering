namespace Backend.Domain.DataStructures.Primitives.Points.Double;

public class DoublePoint2D : Point2D<double>
{
    public DoublePoint2D(double x, double y) : base(x, y)
    {

    }

    public DoublePoint2D Clone() => new(X, Y);

    //TODO improve Point2D Equals method
    #region Equals

    public bool Equals(DoublePoint2D other)
    {
        return X.Equals(other.X) && Y.Equals(other.Y);
    }
    public override bool Equals(object? obj)
    {
        return obj is DoublePoint2D point && Equals(point);
    }

    public override int GetHashCode() => HashCode.Combine(X, Y);

    #endregion


}
