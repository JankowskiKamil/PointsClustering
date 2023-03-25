using Backend.Domain.DataStructures.Primitives.Points.Double;

namespace Backend.Domain.ClusteringMethods.Contract;

public interface ICluster
{
    /// <summary>
    /// Members of this cluster
    /// </summary>
    public IReadOnlyList<DoublePoint2D> Points { get; }
}
