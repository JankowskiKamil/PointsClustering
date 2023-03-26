using Backend.Domain.DataStructures.Primitives.Points.Double;
using Shouldly;
using Xunit;

namespace Tests.Backend.Unit.DataStructures.Primitives.Points.Double;

public static class DoublePoint2DToleranceEqualityComparerTests
{
    [Fact]
    public static void EqualsTwoSamePointsWithoutToleranceReturnsTrue()
    {
        var comparer = new DoublePoint2DToleranceEqualityComparer(0);
        var p1 = new DoublePoint2D(0, 0);
        var p2 = new DoublePoint2D(0, 0);
        comparer.Equals(p1, p2).ShouldBeTrue();
    }
    [Fact]
    public static void EqualsTwoDifferentPointsWithoutToleranceReturnsFalse()
    {
        var comparer = new DoublePoint2DToleranceEqualityComparer(0);
        var p1 = new DoublePoint2D(0, 0);
        var p2 = new DoublePoint2D(1, 0);
        comparer.Equals(p1, p2).ShouldBeFalse();
    }
    [Fact]
    public static void EqualsTwoSamePointsWithToleranceReturnsTrue()
    {
        var comparer = new DoublePoint2DToleranceEqualityComparer(0.001);
        var p1 = new DoublePoint2D(0, 0);
        var p2 = new DoublePoint2D(0, 0.00001);
        comparer.Equals(p1, p2).ShouldBeTrue();
    }
    [Fact]
    public static void EqualsTwoSamePointsWithTooBigToleranceReturnsTrue()
    {
        var comparer = new DoublePoint2DToleranceEqualityComparer(10);
        var p1 = new DoublePoint2D(0, 0);
        var p2 = new DoublePoint2D(0, 0);
        comparer.Equals(p1, p2).ShouldBeTrue();
    }
    [Fact]
    public static void EqualsTwoDifferentPointsWithToleranceReturnsFalse()
    {
        var comparer = new DoublePoint2DToleranceEqualityComparer(0.001);
        var p1 = new DoublePoint2D(0, 0);
        var p2 = new DoublePoint2D(1, 0);
        comparer.Equals(p1, p2).ShouldBeFalse();
    }
    [Fact]
    public static void EqualsTwoSamePointsReturnsCorrectHashSet()
    {
        var comparer = new DoublePoint2DToleranceEqualityComparer(0.001);
        var p1 = new DoublePoint2D(0, 0);
        var p2 = new DoublePoint2D(0, 0);

        var hashSet = new HashSet<DoublePoint2D>(comparer) { p1 };
        hashSet.Count.ShouldBe(1);
        hashSet.Add(p2);
        hashSet.Count.ShouldBe(1);
    }
    [Fact]
    public static void EqualsTwoDifferentPointsReturnsCorrectHashSet()
    {
        var comparer = new DoublePoint2DToleranceEqualityComparer(0.001);
        var p1 = new DoublePoint2D(0, 0);
        var p2 = new DoublePoint2D(10, 0);

        var hashSet = new HashSet<DoublePoint2D>(comparer) { p1 };
        hashSet.Count.ShouldBe(1);
        hashSet.Add(p2);
        hashSet.Count.ShouldBe(2);
    }
}
