using System.Text.Json;
using AIRow.Data;
using AIRow.Loaders;

namespace AIRow.Processors;

public class DataProcessor
{
    private readonly SummaryLoader _summaryLoader;
    private readonly LapsDataLoader _lapsDataLoader;
    private readonly SamplesLoader _samplesLoader;

    public DataProcessor()
    {
        _summaryLoader = new SummaryLoader();
        _lapsDataLoader = new LapsDataLoader();
        _samplesLoader = new SamplesLoader();
    }

    public ActivityData Process(string summaryData, string lapsData, string samplesData)
    {
        var summary = _summaryLoader.Load(summaryData);
        var laps = _lapsDataLoader.Load(lapsData);
        var samples = _samplesLoader.Load(samplesData);

        return new ActivityData(summary, laps, samples);
    }

    public string ExportToJson(ActivityData processedData)
    {
        return JsonSerializer.Serialize(processedData, new JsonSerializerOptions { WriteIndented = true });
    }
}