using AIRow.Predictors;

namespace AIRow.Tests.Predictors;

public class HeartRatePredictorTests
{
    [Fact]
    public void PredictNextMedian_ShouldReturnValidPrediction()
    {
        // Arrange
        var predictor = new HeartRatePredictor();
        var previousSamples = new List<double> { 120, 122, 123, 124, 125 };

        // Act
        var predictedMedian = predictor.PredictNextMedian(previousSamples);

        // Assert
        Assert.Equal(122.8, predictedMedian); // The average of the last 5 samples
    }

    [Fact]
    public void CalculateRMSE_ShouldReturnValidRMSE()
    {
        // Arrange
        var predictor = new HeartRatePredictor();
        var actualValues = new List<double> { 120, 122, 123 };
        var predictedValues = new List<double> { 121, 123, 125 };

        // Act
        var rmse = predictor.CalculateRMSE(actualValues, predictedValues);

        // Assert
        Assert.True(rmse > 0); // RMSE should be greater than 0 if there's error
    }
}