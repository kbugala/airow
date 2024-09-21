using AIRow.Data;
using AIRow.Processors;

namespace AIRow.Tests.Processors;

public class DataProcessorTests
{
    [Fact]
    public void Process_ShouldReturnValidActivityData_WhenGivenValidJson()
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

        var lapsData = @"
        [
            {
                ""startTimeInSeconds"": 1661158927,
                ""totalDistanceInMeters"": 15,
                ""timerDurationInSeconds"": 600,
                ""heartRate"": 109
            },
            {
                ""startTimeInSeconds"": 1661158929,
                ""totalDistanceInMeters"": 30,
                ""timerDurationInSeconds"": 900,
                ""heartRate"": 107
            }
        ]";

        var samplesData = @"
        [
            { ""recording-rate"": 5, ""sample-type"": ""2"", ""data"": ""120,126,122,140,142,155,145"" },
            { ""recording-rate"": 5, ""sample-type"": ""2"", ""data"": ""141,147,155,160,180,152,120"" }
        ]";

        var processor = new DataProcessor();

        // Act
        var activityData = processor.Process(summaryData, lapsData, samplesData);

        // Assert
        Assert.NotNull(activityData);
        Assert.Equal("1234567890", activityData.Summary.UserId);
        Assert.Equal(2, activityData.Laps.Count);
        Assert.Equal(2, activityData.Samples.Count);
    }

    [Fact]
    public void ExportToJson_ShouldReturnJsonString_WhenGivenValidActivityData()
    {
        // Arrange
        var summary = new Summary(
            "1234567890",
            9480958402,
            "Indoor Cycling",
            3667,
            1661158927,
            "INDOOR_CYCLING",
            150,
            561,
            "instinct2",
            190
        );

        var laps = new List<Lap>
        {
            new Lap(1661158927, 15, 600, 109),
            new Lap(1661158929, 30, 900, 107)
        };

        var samples = new List<List<Sample>>
        {
            new List<Sample>
            {
                new Sample(0, 120),
                new Sample(1, 122),
                new Sample(2, 140)
            }
        };

        var processor = new DataProcessor();
        var activityData = new ActivityData(summary, laps, samples);

        // Act
        var jsonOutput = processor.ExportToJson(activityData);

        // Assert
        Assert.Contains("\"userId\": \"1234567890\"", jsonOutput);
        Assert.Contains("\"activityId\": 9480958402", jsonOutput);
        Assert.Contains("\"activityName\": \"Indoor Cycling\"", jsonOutput);
    }
}