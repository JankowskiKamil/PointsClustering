using System.Numerics;

namespace Backend.Domain.DataStructures.Primitives.Points.Contracts;

public interface IPoint2D<T> where T : INumber<T>
{
    public T X { get; }

    public T Y { get; }
}
