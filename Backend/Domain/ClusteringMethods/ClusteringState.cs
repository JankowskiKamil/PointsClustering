namespace Backend.Domain.ClusteringMethods;

public enum ClusteringState
{
    Ok = 0,
    PointsArrayNull = 1,
    DataPointsArrayEmpty = 2,
    MoreCategoriesThanPoints = 3,
    NullEntryInDataPoints = 4,
    DimensionMismatch = 5
}
