using Backend.Domain.DataStructures.Primitives.Points;
using Backend.Domain.DataStructures.Primitives.Points.Double;
using Backend.Domain.DataStructures.Primitives.Points.Int;
using Shouldly;
using Xunit;

namespace Tests.Backend.Unit.DataStructures.Primitives.Points;

public static class Point2DTestsTests
{

    [Fact]
    public static void AddOtherPointReturnsProperPoint()
    {
        var p1 = new DoublePoint2D(5.2, 10.1);
        var p2 = new IntPoint2D(-1, -5);
        var result = p1.Add(p2);
        result.X.ShouldBe(4.2);
        result.Y.ShouldBe(5.1);
    }

    [Fact]
    public static void EqualsToDifferentPointWithTheSameValuesReturnsTrue()
    {
        var p1 = new IntPoint2D(0, 10);
        var p2 = new DoublePoint2D(0, 10);
        p1.Equals(p2).ShouldBeTrue();
    }
    [Fact]
    public static void EqualsToDifferentPointWithDifferentValuesReturnsFalse()
    {
        var p1 = new IntPoint2D(0, 10);
        var p2 = new DoublePoint2D(0, 10.1);
        p1.Equals(p2).ShouldBeFalse();
    }
}
