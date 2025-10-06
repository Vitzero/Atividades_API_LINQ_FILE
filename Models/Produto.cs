using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciciosHash.Models
{
    internal class Produto
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public void MostrarDetalhes()
        {
            Console.WriteLine($"{Nome} - R$ {Preco:F2}");
        }
    }
}
