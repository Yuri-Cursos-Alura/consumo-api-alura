using consumo_api_alura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consumo_api_alura.Filters;
internal static class Filters
{
    public static List<string> GetUniqueGenres(this List<Music> musicas)
    {
        var genresHash = new HashSet<string>();
        musicas.ForEach(m => m.Genres.ForEach(g => genresHash.Add(g)));

        return [.. genresHash];
    }

    public static void PrintUniqueGenres(this List<Music> musicas)
    {
        var uniqueGenres = musicas.GetUniqueGenres();

        foreach (var genres in uniqueGenres)
            Console.WriteLine($"- {genres}");
    }

    public static List<string> GetArtistsByGenre(this List<Music> musicas, string genre)
    {
        return [.. musicas.Where(m => m.IsValid && m.Genre!.Contains(genre, StringComparison.CurrentCultureIgnoreCase)).Select(m => m.Artist).Distinct()];
    }

    public static void PrintArtistsByGenre(this List<Music> musicas, string genre)
    {
        var artists = musicas.GetArtistsByGenre(genre);

        Console.WriteLine($"Artistas por gênero ({genre}): ");
        foreach (var name in artists)
            Console.WriteLine($"- {name}");
    }

    public static List<string> GetMusicByArtist(this List<Music> musicas, string artistName)
    {
        return [.. musicas.Where(m => m.IsValid && m.Artist!.Equals(artistName)).Select(m => m.Name).Distinct()];
    }

    public static void PrintMusicByArtist(this List<Music> musicas, string artistName)
    {
        var musicasByArtist = musicas.GetMusicByArtist(artistName);

        Console.WriteLine($"Musicas por artista ({artistName}): ");
        foreach (var music in musicasByArtist)
            Console.WriteLine($"- {music}");
    }
}
