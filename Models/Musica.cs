﻿using System.Text.Json.Serialization;

namespace ScreenSoundAPI.Models;

internal class Musica
{
    #region Attributes/Properties

    [JsonPropertyName("song")]
    public string? Nome { get; set; }

    [JsonPropertyName("artist")]
    public string? Artista { get; set; }

    [JsonPropertyName("duration_ms")]
    public int Duracao { get; set; }

    [JsonPropertyName("genre")]
    public string? Genero { get; set; }

    [JsonPropertyName("year")]
    public string? AnoString { get; set; }

    public int Ano
    {
        get
        {
            return int.Parse(AnoString!);
        }
    }

    [JsonPropertyName("key")]
    public int Key { get; set; }

    private Dictionary<int, string> notas = new Dictionary<int, string>
    {
        { 0,  "C"  },
        { 1,  "C#" },
        { 2,  "D"  },
        { 3,  "D#" },
        { 4,  "E"  },
        { 5,  "F"  },
        { 6,  "F#" },
        { 7,  "G"  },
        { 8,  "G#" },
        { 9,  "A"  },
        { 10, "A#" },
        { 11, "B"  }
    };

    public string Nota
    {
        get
        {
            if (notas.TryGetValue(Key, out string? value))
            {
                return value;
            }
            else
            {
                return "Nota inválida"; // Ou qualquer mensagem que você preferir
            }
        }
    }

    #endregion

    #region Builders



    #endregion

    #region Methods

    public void ExibeDetalhesMusica()
    {
        Console.WriteLine($"Artista: {Artista}");
        Console.WriteLine($"Música: {Nome}");
        Console.WriteLine($"Duração: {Duracao / 1000}");
        Console.WriteLine($"Gênero musical: {Genero}");
        Console.WriteLine($"Tonalidade: {Nota}");
    }

    //public static string ExibeGenerosMusicais(List<Musica> musicas)
    //{
    //    var generos = musicas.Select(musica => musica.Genero) // Seleciona os gêneros
    //                         .Where(g => g != null) // Filtra os valores null
    //                         .Distinct() // Distinct ignorando dif entre maiúscula/minúscula
    //                         .OrderBy(g => g); // Ordena por ordem alfabética

    //    string generosString = $"Gêneros musicais encontrados: {string.Join("\n ", generos)}";
    //    return generosString;
    //}

    #endregion
}
