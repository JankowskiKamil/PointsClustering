using System.Drawing;
using Backend.Domain.DataStructures.Primitives;
using Backend.Domain.DataStructures.Primitives.Points.Double;
using Shouldly;
using Xunit;

namespace Tests.Backend.Unit.DataStructures.Primitives.Points.Double;

public class DoublePointEqualityComparerTests
{
    [Fact]
    public void EqualsTwoSamePointsWithoutToleranceReturnsTrue()
    {
        var comparer = new DoublePointEqualityComparer(0);
        var p1 = new DoublePoint2D(0, 0);
        var p2 = new DoublePoint2D(0, 0);
        comparer.Equals(p1, p2).ShouldBeTrue();
    }
    [Fact]
    public void EqualsTwoDifferentPointsWithoutToleranceReturnsFalse()
    {
        var comparer = new DoublePointEqualityComparer(0);
        var p1 = new DoublePoint2D(0, 0);
        var p2 = new DoublePoint2D(1, 0);
        comparer.Equals(p1, p2).ShouldBeFalse();
    }
    [Fact]
    public void EqualsTwoSamePointsWithToleranceReturnsTrue()
    {
        var comparer = new DoublePointEqualityComparer(0.001);
        var p1 = new DoublePoint2D(0, 0);
        var p2 = new DoublePoint2D(0, 0.00001);
        comparer.Equals(p1, p2).ShouldBeTrue();
    }
    [Fact]
    public void EqualsTwoSamePointsWithTooBigToleranceReturnsTrue()
    {
        var comparer = new DoublePointEqualityComparer(10);
        var p1 = new DoublePoint2D(0, 0);
        var p2 = new DoublePoint2D(0, 0);
        comparer.Equals(p1, p2).ShouldBeTrue();
    }
    [Fact]
    public void EqualsTwoDifferentPointsWithToleranceReturnsFalse()
    {
        var comparer = new DoublePointEqualityComparer(0.001);
        var p1 = new DoublePoint2D(0, 0);
        var p2 = new DoublePoint2D(1, 0);
        comparer.Equals(p1, p2).ShouldBeFalse();
    }
    [Fact]
    public void EqualsTwoSamePointsReturnsCorrectHashSet()
    {
        var comparer = new DoublePointEqualityComparer(0.001);
        var p1 = new DoublePoint2D(0, 0);
        var p2 = new DoublePoint2D(0, 0);

        var hashSet = new HashSet<DoublePoint2D>(comparer);
        hashSet.Add(p1);
        hashSet.Count.ShouldBe(1);
        hashSet.Add(p2);
        hashSet.Count.ShouldBe(1);
    }
    [Fact]
    public void EqualsTwoDifferentPointsReturnsCorrectHashSet()
    {
        var comparer = new DoublePointEqualityComparer(0.001);
        var p1 = new DoublePoint2D(0, 0);
        var p2 = new DoublePoint2D(10, 0);

        var hashSet = new HashSet<DoublePoint2D>(comparer);
        hashSet.Add(p1);
        hashSet.Count.ShouldBe(1);
        hashSet.Add(p2);
        hashSet.Count.ShouldBe(2);
    }
}
