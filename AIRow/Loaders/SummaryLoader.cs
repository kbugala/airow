using System.Text.Json;
using AIRow.Data;

namespace AIRow.Loaders;

public class SummaryLoader
{
    public Summary Load(string data)
    {
        return JsonSerializer.Deserialize<Summary>(data);
    }
}