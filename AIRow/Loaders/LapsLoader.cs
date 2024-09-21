using System.Text.Json;
using AIRow.Data;

namespace AIRow.Loaders;

public class LapsDataLoader
{
    public List<Lap> Load(string data)
    {
        return JsonSerializer.Deserialize<List<Lap>>(data);
    }
}