using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LojaVirtualTeste
{
    public class Subcategoria : Categoria
    {
        private string nomeSub;
        
        public string NomeSub
        {
            get
            {
                return nomeSub;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(nomeSub) || string.IsNullOrEmpty(nomeSub) || value.Length < 128 || !Regex.IsMatch(nomeSub, "^[a-zA-Z\u00C0-\u00FF ]*$"))
                    nomeSub = value;
                else
                    throw new ArgumentException("Permitido somente letras e até 128 caracteres.");
            }
        }

        public Subcategoria() { }

        public Subcategoria(string nomeSub)
        {
            Nome = nomeSub;
            Status = "Ativo";
        }
    }
}
