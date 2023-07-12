using Ecommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ecommerce
{
    public class Subcategoria
    {
        private string nome;
        public string Nome { get; set; }

        public string Status { get; set; }

        public DateTime DataCriacao = DateTime.Now;

        public DateTime DataAlteracao = DateTime.Now;

        public Subcategoria() { }

        public Subcategoria(string nome)
        {
            Nome = nome;
            Status = "Ativo";
        }
    }
}

