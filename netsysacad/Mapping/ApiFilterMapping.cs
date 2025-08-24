using System.Text.Json;
using System.Text.Json.Serialization;

namespace netsysacad.Mapping;

public class ApiFilter
{
    [JsonPropertyName("field")]
    public required string Field { get; set; }
    [JsonPropertyName("op")]
    public required string Operation { get; set; }
    [JsonPropertyName("value")]
    public required string Value { get; set; }
}

public class ApiFilterMapper
{
    public static List<ApiFilter>? DecodeFilter(string? serializedString)
    {
        if (!string.IsNullOrWhiteSpace(serializedString))
        {
            return JsonSerializer.Deserialize<List<ApiFilter>>(serializedString);
        }
        else
        {
            return null;
        }
    }
}