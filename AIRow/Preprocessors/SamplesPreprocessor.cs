namespace AIRow.Preprocessors;

/// <summary>
/// Outlier Detection and Preprocessing - using the Z-score method to identify outliers and remove them.
/// </summary>
public class SamplesPreprocessor
{
    private const double ZScoreThreshold = 2.0; // Stricter threshold for outlier detection

    // Clean the data by removing outliers based on z-score analysis
    public List<double> CleanOutliers(List<double> data)
    {
        double mean = data.Average();
        double stddev = Math.Sqrt(data.Sum(d => Math.Pow(d - mean, 2)) / data.Count);

        if (stddev == 0) // Edge case: If standard deviation is zero, return the original data.
        {
            return data;
        }

        return data.Where(d => Math.Abs((d - mean) / stddev) < ZScoreThreshold).ToList();
    }

    // Reverse the aggregation step by interpolating back to 5 samples per observation
    public List<double> InterpolateHeartRateObservations(List<double> aggregatedData)
    {
        var interpolatedSamples = new List<double>();

        for (int i = 0; i < aggregatedData.Count - 1; i++)
        {
            double step = (aggregatedData[i + 1] - aggregatedData[i]) / 4;
            for (int j = 0; j < 5; j++)
            {
                interpolatedSamples.Add(aggregatedData[i] + j * step);
            }
        }

        return interpolatedSamples;
    }
}