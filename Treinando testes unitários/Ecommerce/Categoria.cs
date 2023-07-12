using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ecommerce
{
    public class Categoria
    {
        private string nome;
        public string Nome { get; set;}

        public string Status { get; set; }

        public DateTime DataCriacao = DateTime.Now;

        public DateTime DataAlteracao = DateTime.Now;

        public Categoria() { }

        public Categoria(string nome)
        {
            Nome = nome;
            Status = "Ativo";
        }
    }
}
