using AIRow.Loaders;

namespace AIRow.Tests.Loaders;

public class SamplesLoaderTests
{
    [Fact]
    public void Load_ShouldReturnProcessedSamples_WhenGivenValidJson()
    {
        // Arrange
        var samplesData = @"
        [
            { ""recording-rate"": 5, ""sample-type"": ""2"", ""data"": ""120,126,122,140,142,155,145"" },
            { ""recording-rate"": 5, ""sample-type"": ""2"", ""data"": ""141,147,155,160,180,152,120"" }
        ]";
        var samplesLoader = new SamplesLoader();

        // Act
        var samples = samplesLoader.Load(samplesData);

        // Assert
        Assert.Equal(2, samples.Count);  // Two sample groups
        Assert.Equal(30, samples[0].Count);  // First group: 6 intervals * 5 interpolated values
        Assert.Equal(30, samples[1].Count);  // Second group: same logic
        Assert.Equal(120, samples[0][0].HeartRate);  // First sample in first group
        Assert.Equal(141, samples[1][0].HeartRate);  // First sample in second group
    }
}