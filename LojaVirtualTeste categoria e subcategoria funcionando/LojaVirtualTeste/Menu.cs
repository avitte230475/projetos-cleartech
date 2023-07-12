using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LojaVirtualTeste
{
    public class Menu
    {
        private List<Categoria> categorias = new List<Categoria>();
        private List<Subcategoria> subcategorias = new List<Subcategoria>();
        public void ExibirMenu()
        {
            Categoria categoria = new Categoria();
            string comandoEscolhido = "S";

            do
            {
                Console.WriteLine("\nDigite a opção desejada:");
                Console.WriteLine("1 - Cadastrar categoria.");
                Console.WriteLine("2 - Editar categoria.");
                Console.WriteLine("3 - Listar categoria.");
                Console.WriteLine("4 - Cadastrar subcategoria.");
                Console.WriteLine("5 - Editar subcategoria.");
                Console.WriteLine("6 - Listar subcategoria.");
                Console.WriteLine("S - Sair.");

                Console.Write("Opção desejada: ");
                comandoEscolhido = Console.ReadLine();

                switch (comandoEscolhido)
                {
                    case "1":

                        Console.WriteLine("\nNome da categoria: ");
                        string nome = Console.ReadLine();

                        Categoria novaCategoria = new Categoria(nome);
                        novaCategoria.Nome = nome;
                        Console.WriteLine("Nome da Categoria: " + novaCategoria.Nome);
                        Console.WriteLine("Status da Categoria: " + novaCategoria.Status);
                        Console.WriteLine("A data de criação da categoria: " + DateTime.Now);
                        categorias.Add(novaCategoria);
                        Console.WriteLine("Categoria adicionada com sucesso!!!");
                        break;

                    case "2":
                        var opcaoValida = true;

                        while (opcaoValida)
                        {
                            try
                            {
                                Console.WriteLine("Digite o nome da categoria que deseja editar: ");
                                string nomeDaCategoriaPesquisada = Console.ReadLine();
                                var buscandoNomeLista = categorias.Where(c => c.Nome.ToUpper().Equals(nomeDaCategoriaPesquisada.ToUpper()));


                                if (buscandoNomeLista.Count() == 0)
                                {
                                    Console.WriteLine("Categoria não encontrada, digite novamente!\n");
                                }

                                else
                                {
                                    Console.WriteLine("Digite o novo nome da categoria: ");
                                    string novoNome = Console.ReadLine();

                                    if (true)
                                    {
                                        foreach (var c in buscandoNomeLista)
                                        {

                                            c.Nome = novoNome;
                                            c.DataAlteracao = DateTime.Now;
                                            Console.WriteLine("Nome da categoria: " + c.Nome);
                                            Console.WriteLine("Data de criação: " + c.DataCriacao);
                                            Console.WriteLine("Data de alteração: " + c.DataAlteracao);


                                            opcaoValida = false;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Cadastro inválido, apenas 128 caractéres.\n");
                                    }
                                }
                            }

                            catch (ArgumentException e)
                            {
                                Console.WriteLine(e.Message);
                            }

                        }


                        opcaoValida = true;

                        while (opcaoValida)
                        {

                            Console.WriteLine("Deseja ativar o status da Categoria? Digite [1] para Ativar e [2] para Inativar");
                            comandoEscolhido = Console.ReadLine();

                            switch (comandoEscolhido)
                            {

                                case "1":
                                    string Status;
                                    Console.WriteLine("Status da categoria: " + (Status = "Ativo"));
                                    Console.WriteLine("Edição e alteração de Status realizada com sucesso\n");
                                    opcaoValida = false;
                                    break;

                                case "2":

                                    Console.WriteLine("Status da categoria: " + (Status = "Inativo"));
                                    Console.WriteLine("Edição e alteração de Status realizada com sucesso\n");
                                    opcaoValida = false;
                                    break;

                                default:
                                    Console.WriteLine("Parâmetros inválidos. Favor colocar uma opção válida.\n");
                                    break;

                            }
                        }

                        Console.WriteLine("Categoria editada com sucesso!");
                        break;

                    case "3":
                        if (categorias.Count > 0)
                        {
                            Console.WriteLine("Listagem de categorias: ");

                            Console.WriteLine("***********************************************************");

                            foreach (Categoria c in categorias)
                            {
                                Console.WriteLine("Nome da categoria: " + c.Nome);
                                Console.WriteLine("Status da categoria: " + c.Status);
                                Console.WriteLine("Data de criação da categoria: " + c.DataCriacao);
                                Console.WriteLine("Data de alteração: " + c.DataAlteracao + "\n");
                            }
                            Console.WriteLine("Pressione qualquer tecla para prosseguir...");
                            Console.ReadKey();
                        }
                        else
                            Console.WriteLine("Não existem categorias cadastradas.\n");
                        break;
                    case "4":

                        Console.WriteLine("\nNome da subcategoria: ");
                        string nomeSub = Console.ReadLine();

                        Subcategoria novaSubcategoria = new Subcategoria(nomeSub);
                        novaSubcategoria.Nome = nomeSub;
                        Console.WriteLine("Nome da Subcategoria: " + novaSubcategoria.Nome);
                        Console.WriteLine("Status da Subcategoria: " + novaSubcategoria.Status);
                        Console.WriteLine("A data de criação da subcategoria: " + DateTime.Now);
                        subcategorias.Add(novaSubcategoria);
                        Console.WriteLine("Subcategoria adicionada com sucesso!!!");
                        break;

                    case "5":

                        var opcaoValidaSub = true;

                        while (opcaoValidaSub)
                        {
                            try
                            {
                                Console.WriteLine("Digite o nome da subcategoria que deseja editar: ");
                                string nomeDaSubcategoriaPesquisada = Console.ReadLine();
                                var buscandoNomeListaSub = subcategorias.Where(c => c.Nome.ToUpper().Equals(nomeDaSubcategoriaPesquisada.ToUpper()));


                                if (buscandoNomeListaSub.Count() == 0)
                                {
                                    Console.WriteLine("Subcategoria não encontrada, digite novamente!\n");
                                }

                                else
                                {
                                    Console.WriteLine("Digite o novo nome da subcategoria: ");
                                    string novoNome = Console.ReadLine();

                                    if (true)
                                    {
                                        foreach (var s in buscandoNomeListaSub)
                                        {

                                            s.Nome = novoNome;
                                            s.DataAlteracao = DateTime.Now;
                                            Console.WriteLine("Nome da subcategoria: " + s.Nome);
                                            Console.WriteLine("Data de criação: " + s.DataCriacao);
                                            Console.WriteLine("Data de alteração: " + s.DataAlteracao);


                                            opcaoValidaSub = false;
                                        }
                                        
                                    }
                                    else
                                    {
                                        Console.WriteLine("Cadastro inválido, apenas 128 caractéres.\n");
                                    }
                                }
                            }

                            catch (ArgumentException e)
                            {
                                Console.WriteLine(e.Message);
                            }

                        }


                        opcaoValida = true;

                        while (opcaoValida)
                        {

                            Console.WriteLine("Deseja ativar o status da Subcategoria? Digite [1] para Ativar e [2] para Inativar");
                            comandoEscolhido = Console.ReadLine();

                            switch (comandoEscolhido)
                            {

                                case "1":
                                    string Status;
                                    Console.WriteLine("Status da subcategoria: " + (Status = "Ativo"));
                                    Console.WriteLine("Edição e alteração de Status realizada com sucesso\n");
                                    opcaoValida = false;
                                    break;

                                case "2":

                                    Console.WriteLine("Status da subcategoria: " + (Status = "Inativo"));
                                    Console.WriteLine("Edição e alteração de Status realizada com sucesso\n");
                                    opcaoValida = false;
                                    break;

                                default:
                                    Console.WriteLine("Parâmetros inválidos. Favor colocar uma opção válida.\n");
                                    break;

                            }
                        }

                        Console.WriteLine("Subcategoria editada com sucesso!");
                        break;

                    case "6":
                        if (subcategorias.Count > 0)
                        {
                            Console.WriteLine("Listagem de subcategorias: ");

                            Console.WriteLine("***********************************************************");

                            foreach (Subcategoria s in subcategorias)
                            {
                                Console.WriteLine("Nome da subcategoria: " + s.Nome);
                                Console.WriteLine("Status da subcategoria: " + s.Status);
                                Console.WriteLine("Data de criação da subcategoria: " + s.DataCriacao);
                                Console.WriteLine("Data de alteração: " + s.DataAlteracao + "\n");
                            }
                            Console.WriteLine("Pressione qualquer tecla para prosseguir...");
                            Console.ReadKey();
                        }
                        else
                            Console.WriteLine("Não existem subcategorias cadastradas.\n");
                        break;

                    case "S":
                        Console.WriteLine("\nObrigada por usar o programa. ");
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Tente novamente. ");
                        break;
                }
            }
            while (comandoEscolhido != "S");
        }
    }
}
