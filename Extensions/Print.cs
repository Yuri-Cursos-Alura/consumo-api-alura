using consumo_api_alura.Filters;
using consumo_api_alura.Models;

namespace consumo_api_alura.Extensions;
internal static class Print
{
    public static void PrintMusicByArtist(this List<Music> musicas, string artistName)
    {
        List<Music> musicasByArtist = musicas.GetMusicByArtist(artistName);

        Console.WriteLine($"Musicas por artista ({artistName}): ");
        foreach (var music in musicasByArtist)
            if (music.IsValid) Console.WriteLine(music.InLine);
    }

    public static void PrintArtistsByGenre(this List<Music> musicas, string genre)
    {
        List<string> artists = musicas.GetArtistsByGenre(genre);

        Console.WriteLine($"Artistas por gênero ({genre}): ");
        foreach (var name in artists)
            Console.WriteLine($"- {name}");
    }

    public static void PrintUniqueGenres(this List<Music> musicas)
    {
        List<string> uniqueGenres = musicas.GetUniqueGenres();

        foreach (var genres in uniqueGenres)
            Console.WriteLine($"- {genres}");
    }

    public static void PrintMusicByTone(this List<Music> musicas, int tone)
    {
        List<Music> musicByTone = musicas.GetMusicByTone(tone);

        foreach(var music in musicByTone)
            if (music.IsValid) Console.WriteLine(music.InLine);
    }

    public static void PrintMusicByTone(this List<Music> musicas, string tone)
    {
        List<Music> musicByTone = musicas.GetMusicByTone(tone);

        foreach (var music in musicByTone)
            if (music.IsValid) Console.WriteLine(music.InLine);
    }
}
