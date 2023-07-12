using System.Text.RegularExpressions;

namespace EcommerceConsole
{
    public class Categoria
    {
        public List<Categoria> categorias = new List<Categoria>();

        public string Nome { get; private set; }

        public string Status { get; private set; }

        public DateTime DataCriacao = DateTime.Now;

        public DateTime DataAlteracao = DateTime.Now;

        public Categoria() { }

        public Categoria(string nome)
        {
            Nome = nome;
            Status = "Ativo";
        }
        
        public bool validaNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrEmpty(nome) || nome.Length > 128 || !Regex.IsMatch(nome, "^[a-zA-Z\u00C0-\u00FF ]*$"))
            {
                throw new ArgumentException("Permitido somente letras e até 128 caracteres.");
            }

            return true;
        }
        public string Cadastrar()
        {

            var opcaoValida = true;

            while (opcaoValida)
            {
                try
                {
                    Console.WriteLine("Digite o nome da categoria que deseja cadastrar:");
                    string nome = Console.ReadLine();


                    if (validaNome(nome))
                    {
                        Categoria categoria = new Categoria(nome);

                        categoria.Nome = nome;
                        Console.WriteLine("Nome da Categoria: " + categoria.Nome);
                        Console.WriteLine("Status da Categoria: " + categoria.Status);
                        Console.WriteLine("Data de criação da Categoria: " + this.DataCriacao);

                        categorias.Add(categoria);

                        opcaoValida = false;

                    }
                    else
                    {
                        Console.WriteLine("Parâmetros inválidos. Favor colocar até 128 caractéres (Somente letras).\n");
                    }

                }

                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return "Cadastro realizado com sucesso!\n";
            
        }

        public string Editar()
        {

            var opcaoValida = true;

            while (opcaoValida)
            {
                try
                {
                    Console.WriteLine("Comando Escolhido: Editar Categoria.\nDigite o nome da categoria que deseja editar: ");
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

                        if (validaNome(novoNome))
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

                string desejaEditar = Console.ReadLine();

                switch (desejaEditar)
                {

                    case "1":

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

            return "Editado com sucesso!\n";
        }

        public void Listar()
        {
            foreach (Categoria c in categorias)
            {
               
                Console.WriteLine("Nome da categoria: " + c.Nome);
                Console.WriteLine("Status da categoria: " + c.Status);
                Console.WriteLine("Data de criação da categoria: " + c.DataCriacao);
                Console.WriteLine("Data de alteração: " + c.DataAlteracao + "\n");

            }
        }
        
     }
  }





