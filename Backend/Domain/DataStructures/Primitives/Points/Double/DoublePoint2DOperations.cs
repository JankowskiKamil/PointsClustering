
using System.Numerics;
using Backend.Domain.DataStructures.Primitives.Points.Contracts;
using Backend.Domain.DataStructures.Primitives.Points.Double;
using MathNet.Spatial.Units;

namespace Backend.Domain.DataStructures.Primitives;

//TODO generic class for PointOperations?

public static class DoublePointOperations
{

    #region MovingOperations

    public static DoublePoint2D Scale(this DoublePoint2D point, double xScale, double yScale) => new(point.X * xScale, point.Y * yScale);

    public static DoublePoint2D Negate(this DoublePoint2D point) => new(-point.X, -point.Y);

    public static DoublePoint2D Minus(this DoublePoint2D point, DoublePoint2D otherPoint) => new(point.X - otherPoint.X, point.Y - otherPoint.Y);

    public static DoublePoint2D Add(this DoublePoint2D point, DoublePoint2D otherPoint) => new(otherPoint.X + point.X, otherPoint.Y + point.Y);

    public static DoublePoint2D Project(this DoublePoint2D doublePoint, Angle angle, double distance) => new(
        doublePoint.X + Math.Cos(angle.Radians) * distance,
        doublePoint.Y + Math.Sin(angle.Radians) * distance);

    public static DoublePoint2D Rotate(this DoublePoint2D point, Angle angle, DoublePoint2D centerPoint)
    {

        //https://stackoverflow.com/questions/13695317/rotate-a-point-around-another-point
        var cosTheta = Math.Cos(angle.Radians);
        var sinTheta = Math.Sin(angle.Radians);

        var x = (cosTheta * (point.X - centerPoint.X) -
            sinTheta * (point.Y - centerPoint.Y) + centerPoint.X);
        var y = (sinTheta * (point.X - centerPoint.X) +


                 cosTheta * (point.Y - centerPoint.Y) + centerPoint.Y);

        return new DoublePoint2D(x, y);
    }

    #endregion

    #region DistanceMethods

    public static double SquaredDistance(this DoublePoint2D point) => point.X * point.X + point.Y * point.Y;

    public static double SquaredDistanceTo(this DoublePoint2D point, DoublePoint2D other)
    {
        var dx = other.X - point.X;
        var dy = other.Y - point.Y;
        return dx * dx + dy * dy;
    }

    public static double Distance(this DoublePoint2D point) => Math.Sqrt(point.SquaredDistance());

    public static double DistanceTo(this DoublePoint2D point, DoublePoint2D other) =>
        Math.Sqrt(point.SquaredDistanceTo(other));

    #endregion








}
