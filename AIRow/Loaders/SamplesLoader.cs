using System.Text.Json;
using AIRow.Data;
using AIRow.Predictors;
using AIRow.Preprocessors;

namespace AIRow.Loaders;

public class SamplesLoader
{
    private readonly SamplesPreprocessor _preprocessor;
    private readonly HeartRatePredictor _predictor;

    public SamplesLoader()
    {
        _preprocessor = new SamplesPreprocessor();
        _predictor = new HeartRatePredictor();
    }
    
    /// <summary>
    /// Bonus Points: Outlier Detection & Preprocessing (Reversing the Aggregation Step + Model Prediction)
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public List<List<ProcessedSample>> LoadAndProcess(string data)
    {
        var samples = JsonSerializer.Deserialize<List<SampleData>>(data);
        var processedSamples = new List<List<ProcessedSample>>();

        foreach (var sample in samples)
        {
            if (sample.SampleType == "2")
            {
                var interpolatedSamples = _preprocessor.InterpolateHeartRateObservations(
                    sample.Data.Split(',').Select(double.Parse).ToList()
                );

                var cleanedSamples = _preprocessor.CleanOutliers(interpolatedSamples);

                var processed = cleanedSamples.Select((value, index) => new ProcessedSample(index, value)).ToList();
                processedSamples.Add(processed);

                // Example of using the HeartRatePredictor to predict the next median and RMSE validation
                var predictedMedian = _predictor.PredictNextMedian(cleanedSamples);
                Console.WriteLine($"Predicted Median: {predictedMedian}");
            }
        }

        return processedSamples;
    }
    
    public List<List<Sample>> Load(string data)
    {
        var samples = JsonSerializer.Deserialize<List<SampleData>>(data);
        var processedSamples = new List<List<Sample>>();

        foreach (var sample in samples)
        {
            if (sample.SampleType == "2")
            {
                processedSamples.Add(ProcessHeartRateSample(sample.Data));
            }
        }

        return processedSamples;
    }

    private List<Sample> ProcessHeartRateSample(string data)
    {
        var rawData = data.Split(',').Select(int.Parse).ToArray();
        var interpolatedData = Interpolate(rawData);
        var processedSample = new List<Sample>();

        for (int i = 0; i < interpolatedData.Length; i++)
        {
            processedSample.Add(new Sample(i, interpolatedData[i]));
        }

        return processedSample;
    }

    private int[] Interpolate(int[] data)
    {
        var interpolated = new List<int>();

        for (int i = 0; i < data.Length - 1; i++)
        {
            int step = (data[i + 1] - data[i]) / 4;

            for (int j = 0; j < 5; j++)
            {
                interpolated.Add(data[i] + j * step);
            }
        }

        return interpolated.ToArray();
    }
}