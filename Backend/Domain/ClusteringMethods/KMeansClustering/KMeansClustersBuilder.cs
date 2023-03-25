using Backend.Domain.ClusteringMethods.Contract;
using Backend.Domain.DataStructures.Primitives;
using Backend.Domain.DataStructures.Primitives.Points.Double;

namespace Backend.Domain.ClusteringMethods.KMeansClustering;

//https://github.com/kubamaruszczyk1604/KMeansCSharp
//https://towardsdatascience.com/the-5-clustering-algorithms-data-scientists-need-to-know-a36d136ef68
//https://github.com/pedrodbs/Aglomera
public class KMeansClustersBuilder : IClustersBuilder
{
    private readonly int _maxIterations;
    private readonly int _clustersNumber;

    private readonly double _maxDiv;
    private readonly DoublePoint2D[] _pDataPoints;
    private readonly KMeansCluster[] _mClusters;

    private readonly List<int> _sOccupiedCentroidPositions = new(); // This is to keep track of which centroid positions are already occupied during random placement.

    /// <summary>
    /// Create instance of KMeansClustering clasifier.
    /// </summary>
    /// <param name="maxDiv">Mean acceptable divergence</param>
    /// <param name="points">All data points</param>
    /// <param name="clustersNumber">Number of bins</param>
    /// <param name="maxIterations"> Max Iterations</param>
    /// <param name="useRandomCentroidPlacement"> This method can use random centroid placement which makes it not deterministic method. </param>
    /// TODO: Create "seed" approach. We should be able to provide initial centroid placement somehow. Now if useRandomCentroidPlacement is false then we re using first items from array
    public KMeansClustersBuilder(DoublePoint2D[] points, int clustersNumber, int maxIterations = 100, bool useRandomCentroidPlacement = false, double maxDiv = 0.0001d)
    {
        var state = CheckData(points, clustersNumber);
        if (state != ClusteringState.Ok)
        {
            throw new Exception("Data check failed. Reason: " + state.ToString());
        }

        _maxIterations = maxIterations;
        _pDataPoints = points;
        _clustersNumber = clustersNumber;
        _maxDiv = maxDiv;
        _mClusters = new KMeansCluster[clustersNumber];

        for (var i = 0; i < clustersNumber; ++i)
        {
            _mClusters[i] = new KMeansCluster(points, _sOccupiedCentroidPositions, useRandomCentroidPlacement); //adding stuff to _sOccupiedCentroidPositions inside
        }
    }

    /// <summary>
    /// Performs clustering.
    /// </summary>
    /// <returns>Array of clusters, each containing centroid and a list of assigned data points.</returns>
    public ICluster[] Compute()
    {
        var iterations = 0;
        while (iterations < _maxIterations)
        {
            iterations++;
            //clear points in clusters
            foreach (var t in _mClusters)
            {
                t.ClearData();
            }

            //reasing points in clusters
            foreach (var t in _pDataPoints)
            {
                var dist = double.PositiveInfinity;
                var cluster = 0;
                for (var iCluster = 0; iCluster < _mClusters.Length; ++iCluster)
                {
                    var d = _mClusters[iCluster].Centroid.DistanceTo(t);
                    if (!(d < dist)) continue;
                    dist = d;
                    cluster = iCluster;
                }

                _mClusters[cluster].Add(t);
            }

            // recalculate centroids
            var distChanged = _mClusters.Sum(t => t.RecalculateCentroid());

            if (distChanged / _mClusters.Length < _maxDiv)
                break;
        }

        return _mClusters;
    }

    /// <summary>
    /// Prints brief summary of cluster info.
    /// </summary>
    public void PrintClusters()
    {
        Console.WriteLine("Centroids" + new string(' ', 50) + "Members");
        foreach (var t in _mClusters)
        {
            var ptTex = t.Centroid.ToString();
            var diff = 60 - ptTex.Length;
            if (diff < 1) diff = 1;
            ptTex += new string(' ', diff);
            Console.WriteLine(ptTex + " " + t.Points.Count.ToString());
        }
    }

    private static ClusteringState CheckData(IReadOnlyCollection<DoublePoint2D> points, int clustersNumber)
    {
        if (points.Count < 1) return ClusteringState.DataPointsArrayEmpty;
        return points.Count < clustersNumber ? ClusteringState.MoreCategoriesThanPoints : ClusteringState.Ok;
    }
}
