namespace Backend.Domain.DataStructures.Primitives.Points.Uint;

public class UintPoint2D : Point2D<uint>
{

    public UintPoint2D(uint x, uint y) : base(x, y)
    {

    }

    //TODO improve Point2D Equals method
    #region Equals

    public bool Equals(UintPoint2D other)
    {
        return X.Equals(other.X) && Y.Equals(other.Y);
    }
    public override bool Equals(object? obj)
    {
        return obj is UintPoint2D point && Equals(point);
    }

    public override int GetHashCode() => HashCode.Combine(X, Y);

    #endregion
}
