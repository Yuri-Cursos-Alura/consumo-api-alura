using consumo_api_alura.Models.Interfaces;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace consumo_api_alura.Models;
internal class Music : IJsonSerializable
{
    [JsonIgnore]
    private static readonly string[] _keysArray = ["C", "C#", "D", "Eb", "E", "F", "F#", "G", "Ab", "A", "Bb", "B"];

    [JsonPropertyName("song")]
    public string? Name { get; set; }
    [JsonPropertyName("artist")]
    public string? Artist { get; set; }
    [JsonPropertyName("duration_ms")]
    public int? DurationMs { get; set; }
    [JsonPropertyName("genre")]
    public string? Genre { get; set; }
    [JsonPropertyName("key")]
    public int? Key { get; set; }

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
    public string Tone => IsValid ? _keysArray[Key!.Value] : "";

    [JsonIgnore]
    public bool IsValid
    {
        get
        {
            if (Name is null) return false;
            if (Artist is null) return false;
            if (DurationMs is null) return false;
            if (Genre is null) return false;
            if (Key is null) return false;

            return true;
        }
    }

    public void ToJson(string fileName, string filePath = "")
    {
        var finalPath = Path.Combine(filePath, fileName);

        finalPath = Path.ChangeExtension(finalPath, null);

        File.WriteAllText($"{finalPath}.json", JsonSerializer.Serialize(this));
    }



    private string _inLine()
    {
        if (!IsValid) return "Invalid music.";

        return $"- {Name} ({Minutes} minutos) | Feito por {Artist} | Tonalidade {Tone}";
    }

    private string _summary()
    {
        if (!IsValid) return "Invalid music.";

        var summary = "";
        summary += $"Nome: {Name}\n";
        summary += $"Artista: {Artist}\n";
        summary += $"Duração (Minutos): {Minutes}\n";
        summary += $"Gêneros: {Genres}\n";
        summary += $"Tonalidade: {Tone}\n";

        return summary;
    }
}
