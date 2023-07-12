using System.Text.RegularExpressions;

namespace Ecommerce
{
    public class Menu
    {
        private List<Categoria> categorias = new List<Categoria>();
        private List<Subcategoria> subcategorias = new List<Subcategoria>();

        public string Status = "";

        Categoria categoria = new Categoria();
        public void ValidaNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrEmpty(nome) || nome.Length < 128 ||
                !Regex.IsMatch(nome, "^[a-zA-Z\u00C0-\u00FF ]*$")) ;

            else
                throw new ArgumentException("Permitido somente letras e até 128 caracteres.");
        }
        public void Cadastrar(string nome, string status)
        {
            Categoria novaCategoria = new Categoria(nome);
            novaCategoria.Nome = nome;
            Console.WriteLine("Nome da Categoria: " + novaCategoria.Nome);
            Console.WriteLine("Status da Categoria: " + novaCategoria.Status);
            Console.WriteLine("A data de criação da categoria: " + DateTime.Now);
            categorias.Add(novaCategoria);
            Console.WriteLine("Categoria adicionada com sucesso!!!");
        }
        public void Editar(string nome, string status)
        {
            var opcaoValida = true;

            if(opcaoValida)
                {
                    string nomeDaCategoriaPesquisada = "Aline";
                    var buscandoNomeLista = categorias.Where(c => c.Nome.ToUpper().Equals(nomeDaCategoriaPesquisada.ToUpper()));

                    if (buscandoNomeLista.Count() == 0)
                    {
                        Console.WriteLine("Categoria não encontrada.\n");
                    }

                    else
                    {

                        string novoNome = "Sandra";

                        if (true)
                        {
                            foreach (var c in buscandoNomeLista)
                            {

                                c.Nome = novoNome;
                                c.DataAlteracao = DateTime.Now;
                                Console.WriteLine("Nome da categoria: " + c.Nome);
                                Console.WriteLine("Status da Categoria: " + c.Status);
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
            Console.WriteLine("Categoria editada com sucesso!");
            opcaoValida = true;
        }
        public void AlterarStatus()
        {

            if (this.Status == "Ativo")
            {
                this.Status = "Inativo";
            }
            else
            {

                this.Status = "Ativo";
                Console.WriteLine(Status);
                Console.WriteLine("Status da categoria alterado com sucesso!");
            }
        }
        public void Listar()
        {
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
            }
            else
                Console.WriteLine("Não existem categorias cadastradas.\n");
        }
        public void CadastrarSubcategoria(string nome, string status)
        {
            Subcategoria novaSubcategoria = new Subcategoria(nome);
            novaSubcategoria.Nome = nome;
            Console.WriteLine("Nome da Subcategoria: " + novaSubcategoria.Nome);
            Console.WriteLine("Status da Subcategoria: " + novaSubcategoria.Status);
            Console.WriteLine("A data de criação da subcategoria: " + DateTime.Now);
            subcategorias.Add(novaSubcategoria);
            Console.WriteLine("Subcategoria adicionada com sucesso!!!");
        }
        public void EditarSubcategoria(string nome, string status)
        {
            var opcaoValida = true;

            if (opcaoValida)
            {
                string nomeDaSubcategoriaPesquisada = "Vitte";
                var buscandoNomeListaSub = subcategorias.Where(c => c.Nome.ToUpper().Equals(nomeDaSubcategoriaPesquisada.ToUpper()));

                if (buscandoNomeListaSub.Count() == 0)
                {
                    Console.WriteLine("Subcategoria não encontrada.\n");
                }

                else
                {

                    string novoNome = "Oliveira";

                    if (true)
                    {
                        foreach (var s in buscandoNomeListaSub)
                        {

                            s.Nome = novoNome;
                            s.DataAlteracao = DateTime.Now;
                            Console.WriteLine("Nome da subcategoria: " + s.Nome);
                            Console.WriteLine("Status da subcategoria: " + s.Status);
                            Console.WriteLine("Data de criação: " + s.DataCriacao);
                            Console.WriteLine("Data de alteração: " + s.DataAlteracao);


                            opcaoValida = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Cadastro inválido, apenas 128 caractéres.\n");
                    }
                }
            }
            Console.WriteLine("Subcategoria editada com sucesso!");
            opcaoValida = true;
        }
        public void AlterarStatusSubcategoria()
        {

            if (this.Status == "Ativo")
            {
                this.Status = "Inativo";
            }
            else
            {

                this.Status = "Ativo";
                Console.WriteLine(Status);
                Console.WriteLine("Status da subcategoria alterado com sucesso!");
            }
        }
        public void ListarSubcategorias()
        {
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
        }
    }
    
    }


        
    

