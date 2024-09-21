using System.Text.Json.Serialization;

namespace AIRow.Data;

public record SampleData(
    [property: JsonPropertyName("sample-type")] string SampleType,
    [property: JsonPropertyName("data")] string Data
);