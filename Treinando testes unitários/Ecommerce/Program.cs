using Ecommerce;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Ecommerce
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.Cadastrar("Aline", "Ativo");
            menu.Editar("Aline", "Ativo");
            menu.AlterarStatus();
            menu.Listar();
            menu.CadastrarSubcategoria("Vitte", "Ativo");
            menu.EditarSubcategoria("Vitte", "Ativo");
            menu.AlterarStatusSubcategoria();
            menu.ListarSubcategorias();


        }
    }
}
