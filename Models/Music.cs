using System.Text.Json.Serialization;

namespace consumo_api_alura.Models;
internal class Music
{
    [JsonPropertyName("song")]
    public string? Name { get; set; }
    [JsonPropertyName("artist")]
    public string? Artist { get; set; }
    [JsonPropertyName("duration_ms")]
    public int? DurationMs { get; set; }
    [JsonPropertyName("genre")]
    public string? Genre { get; set; }

    [JsonIgnore]
    public TimeSpan Duration => IsValid ? new TimeSpan(0, 0, 0, 0, 0, microseconds: DurationMs!.Value) : new TimeSpan(0);

    [JsonIgnore]
    public bool IsValid
    {
        get
        {
            if (Name is null) return false;
            if (Artist is null) return false;
            if (DurationMs is null) return false;
            if (Genre is null) return false;

            return true;
        }
    }
}
