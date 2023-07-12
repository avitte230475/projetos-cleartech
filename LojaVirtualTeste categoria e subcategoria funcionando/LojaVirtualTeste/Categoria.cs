using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LojaVirtualTeste
{
    public class Categoria
    {
        private string nome;
        public string Nome
        {
            get
            {
                return nome;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrEmpty(nome) || value.Length < 128 || !Regex.IsMatch(nome, "^[a-zA-Z\u00C0-\u00FF ]*$"))
                    nome = value;
                else
                    throw new ArgumentException("Permitido somente letras e até 128 caracteres.");
            }
        }

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
