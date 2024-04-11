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
    public TimeSpan Duration => IsValid ? new TimeSpan(0, 0, 0, 0, milliseconds: DurationMs!.Value) : new TimeSpan(0);
    [JsonIgnore]
    public string Minutes => string.Format("{0:0.0}", Duration.TotalMinutes);
    [JsonIgnore]
    public List<string> Genres => IsValid ? [.. Genre!.Split(", ")] : [];
    [JsonIgnore]
    public string Summary => _summary();
    [JsonIgnore]
    public string InLine => _inLine();

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

    private string _inLine()
    {
        if (!IsValid) return "Invalid music.";

        return $"- {Name} ({Minutes} minutos) | Feito por {Artist}";
    }

    private string _summary()
    {
        if (!IsValid) return "Invalid music.";

        var summary = "";
        summary += $"Nome: {Name}";
        summary += $"Artista: {Artist}";
        summary += $"Duração (Minutos): {Minutes}";
        summary += $"Gêneros: {Genres}";

        return summary;
    }
}
