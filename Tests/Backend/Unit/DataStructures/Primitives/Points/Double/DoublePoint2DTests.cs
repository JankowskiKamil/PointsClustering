using Backend.Domain.DataStructures.Primitives.Points;
using Backend.Domain.DataStructures.Primitives.Points.Double;
using MathNet.Spatial.Units;
using Shouldly;
using Xunit;

namespace Tests.Backend.Unit.DataStructures.Primitives.Points.Double;

public static class DoublePoint2DTests
{
    [Fact]
    public static void AddOtherPointReturnsProperPoint()
    {
        var p1 = new DoublePoint2D(5, 10);
        var p2 = new DoublePoint2D(-1, -5);
        var result = p1.Add(p2);
        result.X.ShouldBe(4);
        result.Y.ShouldBe(5);
    }

    [Fact]
    public static void MinusOtherPointReturnsProperPoint()
    {
        var p1 = new DoublePoint2D(5, 10);
        var p2 = new DoublePoint2D(-1, -5);
        var result = p1.Minus(p2);
        result.X.ShouldBe(6);
        result.Y.ShouldBe(15);
    }


    [Fact]
    public static void NegatePointReturnsProperPoint()
    {
        var p1 = new DoublePoint2D(5, 10);
        var result = p1.Negate();
        result.X.ShouldBe(-5);
        result.Y.ShouldBe(-10);
    }

    [Fact]
    public static void ProjectPointReturnsProperPoint()
    {
        var p1 = new DoublePoint2D(0, 0);
        var angle = Angle.FromDegrees(90);
        var result = p1.Project(angle, 10);
        result.X.ShouldBeInRange(0, 0.000001);
        result.Y.ShouldBe(10);
    }

    [Fact]
    public static void RotatePointReturnsProperPoint()
    {
        var p1 = new DoublePoint2D(0, 0);
        var center = new DoublePoint2D(10, 0);
        var angle = Angle.FromDegrees(180);
        var result = p1.Rotate(angle, center);
        result.X.ShouldBe(20);
        result.Y.ShouldBeInRange(-0.000001, 0.000001);
    }

    [Fact]
    public static void DistanceToPointReturnsProperValue()
    {
        var p1 = new DoublePoint2D(0, 0);
        var p2 = new DoublePoint2D(0, 10);
        p1.DistanceTo(p2).ShouldBe(10);
    }

    [Fact]
    public static void EqualsTwoSamePointsReturnsCorrectHashSet()
    {

        var p1 = new DoublePoint2D(0, 0);
        var p2 = new DoublePoint2D(0, 0);

        var hashSet = new HashSet<DoublePoint2D>() { p1 };
        hashSet.Count.ShouldBe(1);
        hashSet.Add(p2);
        hashSet.Count.ShouldBe(1);
    }
    [Fact]
    public static void EqualsTwoDifferentPointsReturnsCorrectHashSet()
    {
        var p1 = new DoublePoint2D(0, 0);
        var p2 = new DoublePoint2D(10, 0);

        var hashSet = new HashSet<DoublePoint2D>() { p1 };
        hashSet.Count.ShouldBe(1);
        hashSet.Add(p2);
        hashSet.Count.ShouldBe(2);
    }
}
