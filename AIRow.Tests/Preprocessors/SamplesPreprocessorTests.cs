using AIRow.Preprocessors;

namespace AIRow.Tests.Preprocessors;

public class SamplesPreprocessorTests
{
    [Fact]
    public void CleanOutliers_ShouldRemoveOutliersFromData()
    {
        // Arrange
        var preprocessor = new SamplesPreprocessor();
        var data = new List<double> { 120, 122, 123, 1500, 124, 121 }; // 1500 is an outlier

        // Act
        var cleanedData = preprocessor.CleanOutliers(data);

        // Assert
        Assert.DoesNotContain(1500, cleanedData); // 1500 should be removed as an outlier
        Assert.Equal(5, cleanedData.Count);               // Only 5 values should remain
    }

    [Fact]
    public void InterpolateHeartRateObservations_ShouldReturnInterpolatedValues()
    {
        // Arrange
        var preprocessor = new SamplesPreprocessor();
        var aggregatedData = new List<double> { 120, 125 }; // Simple data

        // Act
        var interpolated = preprocessor.InterpolateHeartRateObservations(aggregatedData);

        // Assert
        Assert.Equal(5, interpolated.Count); // Should interpolate to 5 values
        Assert.Equal(120, interpolated[0]); // First value should match the original
    }
}