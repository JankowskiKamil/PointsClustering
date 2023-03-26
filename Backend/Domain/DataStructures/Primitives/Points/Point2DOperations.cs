using System.Numerics;
using Backend.Domain.DataStructures.Primitives.Points.Double;

namespace Backend.Domain.DataStructures.Primitives.Points;

public static class Point2DOperations
{

    #region MovingOperations

    public static Point2D<T> Add<T>(this Point2D<T> point, Point2D<T> otherPoint) where T : INumber<T>
    {
        return new Point2D<T>(otherPoint.X + point.X, otherPoint.Y + point.Y);
    }

    public static DoublePoint2D Add<T, TM>(this Point2D<T> point, Point2D<TM> otherPoint) where T : INumber<T> where TM : INumber<TM>
    {
        return new DoublePoint2D(Convert.ToDouble(otherPoint.X) + Convert.ToDouble(point.X), Convert.ToDouble(otherPoint.Y) + Convert.ToDouble(point.Y));
    }


    #endregion

    #region Distance

    public static double DistanceTo<T, TM>(this Point2D<T> point, Point2D<TM> other) where T : INumber<T> where TM : INumber<TM>
    {
        var dx = Convert.ToDouble(other.X) - Convert.ToDouble(point.X);
        var dy = Convert.ToDouble(other.Y) - Convert.ToDouble(point.Y);
        return Math.Sqrt(dx * dx + dy * dy);
    }

    #endregion

}
