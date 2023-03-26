namespace Backend.Domain.DataStructures.Primitives.Points.Int;

public class IntPoint2D : Point2D<int>
{

    public IntPoint2D(int x, int y) : base(x, y)
    {

    }

    //TODO improve Point2D Equals method
    #region Equals

    public bool Equals(IntPoint2D other)
    {
        return X.Equals(other.X) && Y.Equals(other.Y);
    }
    public override bool Equals(object? obj)
    {
        return obj is IntPoint2D point && Equals(point);
    }

    public override int GetHashCode() => HashCode.Combine(X, Y);

    #endregion
}
