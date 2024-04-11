
using consumo_api_alura.Extensions;
using consumo_api_alura.Filters;
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
        Console.WriteLine("Unable to get endpoint.");
        return;
    }

    var musicas = JsonSerializer.Deserialize<List<Music>>(response);

    if (musicas is null)
    {
        Console.WriteLine("Was not able to deserialize to List<Music>.");
        return;
    }

    musicas.GetMusicByArtist("U2").ToJson("U2-songs.json");
}