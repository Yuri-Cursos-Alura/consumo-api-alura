using consumo_api_alura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consumo_api_alura.Extensions;
internal static class Validation
{
    public static bool IsValid(this List<Music> musicas)
    {
        return musicas.All(m => m.IsValid);
    }
}
