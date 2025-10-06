using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciciosHash.Models
{
    using System;
    using System.Collections.Generic;

    class Livro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int AnoPublicacao { get; set; }

        public void MostrarDetalhes()
        {
            Console.WriteLine($"{Titulo} - {Autor} ({AnoPublicacao})");
        }
    }
}
