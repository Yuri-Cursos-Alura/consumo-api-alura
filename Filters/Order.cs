using consumo_api_alura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consumo_api_alura.Filters;
internal static class Order
{
    public static List<string> GetOrderedArtistsAsc(this List<Music> music)
    {
        return [.. music.OrderBy(m => m.Artist).Select(m => m.Artist).Distinct()];
    }

    public static void PrintOrderedArtistsAsc(this List<Music> music)
    {
        var artists = music.GetOrderedArtistsAsc();

        foreach (var artist in artists)
            Console.WriteLine($"- {artist}");
    }
}
