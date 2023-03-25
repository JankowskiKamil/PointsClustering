using Backend.Domain.DataStructures.Primitives;
using Backend.Domain.DataStructures.Primitives.Points.Double;
using MathNet.Spatial.Units;
using Shouldly;
using Xunit;

namespace Tests.Backend.Unit.DataStructures.Primitives.Points.Double;

public class DoublePointTests
{
    [Fact]
    public void AddOtherPointReturnsProperPoint()
    {
        var p1 = new DoublePoint(5,10);
        var p2 = new DoublePoint(-1, -5);
        var result = p1.Add(p2);
        result.X.ShouldBe(4);
        result.Y.ShouldBe(5);
    }

    [Fact]
    public void MinusOtherPointReturnsProperPoint()
    {
        var p1 = new DoublePoint(5,10);
        var p2 = new DoublePoint(-1, -5);
        var result = p1.Minus(p2);
        result.X.ShouldBe(6);
        result.Y.ShouldBe(15);
    }


    [Fact]
    public void NegatePointReturnsProperPoint()
    {
        var p1 = new DoublePoint(5,10);
        var result = p1.Negate();
        result.X.ShouldBe(-5);
        result.Y.ShouldBe(-10);
    }

    [Fact]
    public void ProjectPointReturnsProperPoint()
    {
        var p1 = new DoublePoint(0,0);
        var angle = Angle.FromDegrees(90);
        var result = p1.Project(angle, 10);
        result.X.ShouldBeInRange(0,0.000001);
        result.Y.ShouldBe(10);
    }

    [Fact]
    public void RotatePointReturnsProperPoint()
    {
        var p1 = new DoublePoint(0,0);
        var center = new DoublePoint(10, 0);
        var angle = Angle.FromDegrees(180);
        var result = p1.Rotate(angle, center);
        result.X.ShouldBe(20);
        result.Y.ShouldBeInRange(-0.000001,0.000001);
    }

    [Fact]
    public void DistanceToPointReturnsProperValue()
    {
        var p1 = new DoublePoint(0,0);
        var p2 = new DoublePoint(0,10);
        p1.DistanceTo(p2).ShouldBe(10);
    }
}
