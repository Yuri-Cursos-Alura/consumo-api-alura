using consumo_api_alura.Models;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

namespace consumo_api_alura.Extensions;
internal static class Serialization
{
    public static void ToJson(this List<Music> musicas, string fileName, string filePath = "")
    {
        if (!musicas.IsValid())
        {
            Console.Error.WriteLine("Nem todas as músicas são válidas.");
            return;
        }

        var finalPath = Path.Combine(filePath, fileName);

        finalPath = Path.ChangeExtension(finalPath, null);

        File.WriteAllText($"{finalPath}.json", JsonSerializer.Serialize(musicas));
    }
}
