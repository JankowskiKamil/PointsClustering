namespace Backend.Domain.ClusteringMethods.Contract;

public interface IClustersBuilder
{
    public ICluster[] Compute();
}
