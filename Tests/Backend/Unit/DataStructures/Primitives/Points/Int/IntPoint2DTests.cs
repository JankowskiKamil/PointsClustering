using Backend.Domain.DataStructures.Primitives.Points;
using Backend.Domain.DataStructures.Primitives.Points.Int;
using Shouldly;
using Xunit;

namespace Tests.Backend.Unit.DataStructures.Primitives.Points.Int;

public static class IntPoint2DTests
{

    [Fact]
    public static void SimpleDistanceToPointReturnsProperValue()
    {
        var p1 = new IntPoint2D(0, 0);
        var p2 = new IntPoint2D(0, 10);
        p1.DistanceTo(p2).ShouldBe(10);
    }
    [Fact]
    public static void ComplexDistanceToPointReturnsProperValue()
    {
        var p1 = new IntPoint2D(0, 0);
        var p2 = new IntPoint2D(1, 1);
        p1.DistanceTo(p2).ShouldBeInRange(1.4, 1.42);
    }
}
