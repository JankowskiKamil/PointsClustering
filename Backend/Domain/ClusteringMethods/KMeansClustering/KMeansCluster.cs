using Backend.Domain.ClusteringMethods.Contract;
using Backend.Domain.DataStructures.Primitives;
using Backend.Domain.DataStructures.Primitives.Points.Double;

namespace Backend.Domain.ClusteringMethods.KMeansClustering;

/// <summary>
/// This class represents data point cluster.
/// It contains centroid and a list of references to member data points.
/// </summary>
public class KMeansCluster : ICluster
{
    #region PublicProperties

    /// <summary>
    /// Centre point of a cluster
    /// </summary>
    public DoublePoint2D Centroid { get; set; }


    /// <summary>
    /// Members of this cluster
    /// </summary>
    public IReadOnlyList<DoublePoint2D> Points
    {
        get { return _points; }
    }

    #endregion

    #region PrivateProperties

    private readonly List<DoublePoint2D> _points;

    #endregion

    private DoublePoint2D _mLastCentroid;


    /// <summary>
    /// Places centroid at the position of a point randomly selected from the data.
    /// </summary>
    /// <param name="allData"></param>
    /// <param name="sOccupiedCentroidPositions"></param>
    /// <param name="randomCentroidPlacement"></param>
    public KMeansCluster(IReadOnlyList<DoublePoint2D> allData, ICollection<int> sOccupiedCentroidPositions, bool randomCentroidPlacement = true)
    {
        _points = new List<DoublePoint2D>();

        var index = 0;

        if (randomCentroidPlacement)
        {
            var cnt = 0;
            var rnd = new Random();
            do
            {
                cnt++;
                if (cnt > 100)
                {
                    throw new Exception("Cannot do centroid placement.");
                }

                index = rnd.Next(allData.Count);
            } while (sOccupiedCentroidPositions.Contains(index));
        }
        else
        {
            while (sOccupiedCentroidPositions.Contains(index))
            {
                index++;
            }

            if (index > allData.Count - 1)
            {
                throw new Exception("Cannot do centroid placement.");
            }
        }

        var selectedCentroid = allData[index];

        Centroid = selectedCentroid.Clone();
        sOccupiedCentroidPositions.Add(index);
        _mLastCentroid = selectedCentroid.Clone();
    }

    /// <summary>
    /// Clears references to dataPoints used for centroid recalculation
    /// </summary>
    public void ClearData()
    {
        _points.Clear();
    }

    public void Add(DoublePoint2D point)
    {
        _points.Add(point);
    }

    /// <summary>
    /// Updates centroid position in respect to cluster data data points
    /// </summary>
    /// <returns></returns>
    public double RecalculateCentroid()
    {
        if (Points.Count == 0)
        {
            return 0;
        }

        var mean = new double[2]; //Point has X and Y only
        foreach (var t in Points)
        {
            mean[0] += t.X;
            mean[1] += t.Y;
        }

        _mLastCentroid = Centroid.Clone();
        Centroid = new DoublePoint2D(x: mean[0] /= Points.Count, y: mean[1] /= Points.Count);
        return Centroid.DistanceTo(_mLastCentroid);
    }
}
