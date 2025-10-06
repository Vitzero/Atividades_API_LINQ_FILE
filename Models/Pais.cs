using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Globalization;

namespace ExerciciosHash.Models
{
    internal class Pais
    {
        CultureInfo culture = CultureInfo.InvariantCulture;

        [JsonPropertyName("nome")]
        public string Name { get; set; }
        [JsonPropertyName("capital")]
        public string Capital { get; set; }
        [JsonPropertyName("populacao")]
        public int population { get; set; }
        [JsonPropertyName("continente")]
        public string continent { get; set; }
        [JsonPropertyName("idioma")]
        public string language { get; set; }

        public void ShowDetails()
        {
            Console.WriteLine(Name);
            Console.WriteLine(Capital);
            Console.WriteLine($"{ population.ToString("N0", culture)}");
            Console.WriteLine(continent);
            Console.WriteLine(language);
        }
    }
}
