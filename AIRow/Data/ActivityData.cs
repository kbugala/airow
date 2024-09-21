namespace AIRow.Data;

public record ActivityData(
    Summary Summary,
    List<Lap> Laps,
    List<List<Sample>> Samples
);