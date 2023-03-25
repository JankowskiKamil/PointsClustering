
using MathNet.Spatial.Units;

namespace Backend.Domain.DataStructures.Primitives;

public static class DoublePointOperations
{

    #region MovingOperations

    public static DoublePoint Scale(this DoublePoint point, double xScale, double yScale) => new(point.X * xScale, point.Y * yScale);

    public static DoublePoint Move(this DoublePoint point, double x, double y) => new(point.X + x, point.Y + y);

    public static DoublePoint Negate(this DoublePoint point) => new(-point.X, -point.Y);

    public static DoublePoint Minus(this DoublePoint point, DoublePoint otherPoint) => new(point.X - otherPoint.X, point.Y - otherPoint.Y);

    public static DoublePoint Add(this DoublePoint point, DoublePoint otherPoint) => new(otherPoint.X + point.X, otherPoint.Y + point.Y);

    public static DoublePoint Project(this DoublePoint doublePoint, Angle angle, double distance) => new(
        doublePoint.X + Math.Cos(angle.Radians) * distance,
        doublePoint.Y + Math.Sin(angle.Radians) * distance);

    public static DoublePoint RotatePoint(this DoublePoint point, Angle angle, DoublePoint centerPoint)
    {

        //https://stackoverflow.com/questions/13695317/rotate-a-point-around-another-point
        var cosTheta = Math.Cos(angle.Radians);
        var sinTheta = Math.Sin(angle.Radians);

        var x = (cosTheta * (point.X - centerPoint.X) -
            sinTheta * (point.Y - centerPoint.Y) + centerPoint.X);
        var y = (sinTheta * (point.X - centerPoint.X) +


                 cosTheta * (point.Y - centerPoint.Y) + centerPoint.Y);

        return new DoublePoint(x, y);
    }

    #endregion

    #region DistanceMethods

    public static double SquaredDistance(this DoublePoint point) => point.X * point.X + point.Y * point.Y;

    public static double SquaredDistanceTo(this DoublePoint point, DoublePoint other)
    {
        var dx = other.X - point.X;
        var dy = other.Y - point.Y;
        return dx * dx + dy * dy;
    }

    public static double Distance(this DoublePoint point) => Math.Sqrt(point.SquaredDistance());

    public static double DistanceTo(this DoublePoint point, DoublePoint other) =>
        Math.Sqrt(point.SquaredDistanceTo(other));

    #endregion








}
