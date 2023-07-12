using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceConsole
{
    public class Menu
    {
        public static void ExibirMenu()
        {

            Categoria categoria = new Categoria();
            var opcaoValida = true;
            while (opcaoValida)
            {
                Console.WriteLine("1) Cadastrar categoria\n2) Editar categoria\n3) Listar categorias\n0) Sair");
                Console.WriteLine("\nDigite a opção desejada:");
                string comandoEscolhido = Console.ReadLine();

                Console.WriteLine();

                switch (comandoEscolhido)
                {
                    case "1":

                        Console.WriteLine(categoria.Cadastrar());
                        break;

                    case "2":

                        Console.WriteLine(categoria.Editar());
                        break;

                    case "3":
                        categoria.Listar();
                        break;

                    case "0":
                        Console.WriteLine("Obrigado por utilizar o sistema, aperte enter para sair...");
                        opcaoValida = false;
                        break;

                    default:
                        Console.WriteLine("Digite uma opção válida!");
                        Console.WriteLine();

                        break;
                }


            }
        }
    }
}
    

