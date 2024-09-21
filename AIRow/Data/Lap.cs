using System.Text.Json.Serialization;

namespace AIRow.Data;

public record Lap(
    [property: JsonPropertyName("startTimeInSeconds")] long StartTimeInSeconds,
    [property: JsonPropertyName("totalDistanceInMeters")] int TotalDistanceInMeters,
    [property: JsonPropertyName("timerDurationInSeconds")] int TimerDurationInSeconds,
    [property: JsonPropertyName("heartRate")] int HeartRate
);