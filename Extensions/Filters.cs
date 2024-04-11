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

    public static List<string> GetArtistsByGenre(this List<Music> musicas, string genre)
    {
        return [.. musicas.Where(m => m.IsValid && m.Genre!.Contains(genre, StringComparison.CurrentCultureIgnoreCase)).Select(m => m.Artist).Distinct()];
    }

    public static List<Music> GetMusicByArtist(this List<Music> musicas, string artistName)
    {
        return [.. musicas.Where(m => m.IsValid && m.Artist!.Equals(artistName)).Distinct()];
    }

    public static List<Music> GetMusicByTone(this List<Music> musicas, int tone)
    {
        return [.. musicas.Where(m => m.Key == tone)];
    }

    public static List<Music> GetMusicByTone(this List<Music> musicas, string tone)
    {
        return [.. musicas.Where(m => m.Tone.Equals(tone))];
    }
}
