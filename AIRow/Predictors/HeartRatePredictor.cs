namespace AIRow.Predictors;

/// <summary>
/// A simple predictive model that uses previous heart rate samples to predict the median of the next five values.
/// This class will perform model training and testing, using Root Mean Squared Error (RMSE) as the error metric to evaluate the performance of the model.
/// </summary>
public class HeartRatePredictor
{
    // Predict the median of the next 5 heart rate samples based on previous samples
    public double PredictNextMedian(List<double> previousSamples)
    {
        // For simplicity, the prediction is the average of the last 5 samples
        return previousSamples.Skip(previousSamples.Count - 5).Average();
    }

    // Calculate the RMSE (Root Mean Squared Error) between predicted and actual values
    public double CalculateRMSE(List<double> actualValues, List<double> predictedValues)
    {
        if (actualValues.Count != predictedValues.Count)
        {
            throw new ArgumentException("The number of actual and predicted values must be the same.");
        }

        double sumSquaredErrors = 0.0;

        for (int i = 0; i < actualValues.Count; i++)
        {
            sumSquaredErrors += Math.Pow(actualValues[i] - predictedValues[i], 2);
        }

        return Math.Sqrt(sumSquaredErrors / actualValues.Count);
    }
}