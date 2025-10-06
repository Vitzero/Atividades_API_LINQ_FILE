using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ExerciciosHash.Models
{
    internal class Filme
    {
        [JsonPropertyName("rank")]
        public string Rank { get; set; }
        
        [JsonPropertyName("title")]
        public string Name { get; set; }
        
        [JsonPropertyName("year")]    
        public string Year { get; set; }

        [JsonPropertyName("imDbRating")]
        public string Rate { get; set; }

        [JsonPropertyName("imDbRatingCount")]
        public string Quantity { get; set; }


        public void ShowDetails()
        {
            Console.WriteLine($"{Rank}");
            Console.WriteLine($"{Name}");
            Console.WriteLine($"{Year}");
            Console.WriteLine($"{Rate:F2}");
            Console.WriteLine($"{Quantity}");
        }
    }
}
