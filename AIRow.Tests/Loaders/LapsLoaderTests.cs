using AIRow.Loaders;

namespace AIRow.Tests.Loaders;

public class LapsDataLoaderTests
{
    [Fact]
    public void Load_ShouldReturnValidLaps_WhenGivenValidJson()
    {
        // Arrange
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
        var lapsLoader = new LapsDataLoader();

        // Act
        var laps = lapsLoader.Load(lapsData);

        // Assert
        Assert.Equal(2, laps.Count);
        Assert.Equal(1661158927, laps[0].StartTimeInSeconds);
        Assert.Equal(15, laps[0].TotalDistanceInMeters);
        Assert.Equal(109, laps[0].HeartRate);
        Assert.Equal(1661158929, laps[1].StartTimeInSeconds);
        Assert.Equal(30, laps[1].TotalDistanceInMeters);
        Assert.Equal(107, laps[1].HeartRate);
    }
}