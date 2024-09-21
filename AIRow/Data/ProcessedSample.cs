namespace AIRow.Data;

/// <summary>
/// A record to store pre-processed heart rate samples
/// </summary>
/// <param name="SampleIndex"></param>
/// <param name="HeartRate"></param>
public record ProcessedSample(
    int SampleIndex,
    double HeartRate
);