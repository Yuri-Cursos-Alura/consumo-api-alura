
using consumo_api_alura.Models;
using System.Net;
using System.Text.Json;

var endpoint = "https://guilhermeonrails.github.io/api-csharp-songs/songs.json";


using (HttpClient client = new())
{
    var httpResponse = await client.GetAsync(endpoint);

    string? response = httpResponse.IsSuccessStatusCode ? await httpResponse.Content.ReadAsStringAsync() : null;
    
    if (response is null)
    {
        Console.WriteLine("Unable to get enpoint.");
        return;
    }

    var musicas = JsonSerializer.Deserialize<List<Music>>(response);

    if (musicas is null)
    {
        Console.WriteLine("Was not able to deserialize to List<Music>.");
        return;
    }

    foreach (var musica in musicas)
    {
        Console.WriteLine($"- {musica.Name} | IsValid: {musica.IsValid}");
    }
}