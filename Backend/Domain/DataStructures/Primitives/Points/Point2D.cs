using System.Numerics;

namespace Backend.Domain.DataStructures.Primitives.Points;

public class Point2D<T> where T : INumber<T>
{

    public T X { get; }

    public T Y { get; }

    public Point2D(T x, T y)
    {
        X = x;
        Y = y;
    }


    #region Equals

    public bool Equals<TM>(Point2D<TM> other) where TM : INumber<TM> //How to compare numbers without double conversion???
    {
        return Convert.ToDouble(X).Equals(Convert.ToDouble(other.X)) &&
               Convert.ToDouble(Y).Equals(Convert.ToDouble(other.Y));
    }

    public override bool Equals(object? obj) //How to check generic type? IntPoint is different than DoublePoint because of generic
    {
        return obj is Point2D<T> point && Equals(point);
    }

    public override int GetHashCode() => HashCode.Combine(X, Y);

    #endregion

    public override string ToString()
    {
        return $"[{X}, {Y}]";
    }

}

