using AIRow.Loaders;

namespace AIRow.Tests.Loaders;

public class SummaryLoaderTests
{
    [Fact]
    public void Load_ShouldReturnValidSummary_WhenGivenValidJson()
    {
        // Arrange
        var summaryData = @"
        {
            ""userId"": ""1234567890"",
            ""activityId"": 9480958402,
            ""activityName"": ""Indoor Cycling"",
            ""durationInSeconds"": 3667,
            ""startTimeInSeconds"": 1661158927,
            ""activityType"": ""INDOOR_CYCLING"",
            ""averageHeartRateInBeatsPerMinute"": 150,
            ""activeKilocalories"": 561,
            ""deviceName"": ""instinct2"",
            ""maxHeartRateInBeatsPerMinute"": 190
        }";
        var summaryLoader = new SummaryLoader();

        // Act
        var summary = summaryLoader.Load(summaryData);

        // Assert
        Assert.Equal("1234567890", summary.UserId);
        Assert.Equal(9480958402, summary.ActivityId);
        Assert.Equal("Indoor Cycling", summary.ActivityName);
        Assert.Equal(3667, summary.DurationInSeconds);
        Assert.Equal(150, summary.AverageHeartRateInBeatsPerMinute);
        Assert.Equal(190, summary.MaxHeartRateInBeatsPerMinute);
    }
    
    [Fact]
    public void LoadAndProcess_ShouldCleanAndInterpolateSamples()
    {
        // Arrange
        var samplesData = @"
        [
            { ""recording-rate"": 5, ""sample-type"": ""2"", ""data"": ""120,126,122,140,142,155,145"" }
        ]";
        var samplesLoader = new SamplesLoader();

        // Act
        var processedSamples = samplesLoader.LoadAndProcess(samplesData);

        // Assert
        Assert.Single(processedSamples); // One sample group
        Assert.True(processedSamples[0].Count > 0); // Processed and interpolated
    }
}