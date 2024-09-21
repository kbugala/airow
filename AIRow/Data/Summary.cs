using System.Text.Json.Serialization;

namespace AIRow.Data;

public record Summary(
    [property: JsonPropertyName("userId")] string UserId,
    [property: JsonPropertyName("activityId")] long ActivityId,
    [property: JsonPropertyName("activityName")] string ActivityName,
    [property: JsonPropertyName("durationInSeconds")] int DurationInSeconds,
    [property: JsonPropertyName("startTimeInSeconds")] long StartTimeInSeconds,
    [property: JsonPropertyName("activityType")] string ActivityType,
    [property: JsonPropertyName("averageHeartRateInBeatsPerMinute")] int AverageHeartRateInBeatsPerMinute,
    [property: JsonPropertyName("activeKilocalories")] int ActiveKilocalories,
    [property: JsonPropertyName("deviceName")] string DeviceName,
    [property: JsonPropertyName("maxHeartRateInBeatsPerMinute")] int MaxHeartRateInBeatsPerMinute
);