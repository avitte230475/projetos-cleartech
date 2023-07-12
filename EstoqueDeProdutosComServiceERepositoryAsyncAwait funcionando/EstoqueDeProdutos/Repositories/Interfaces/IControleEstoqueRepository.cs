using EstoqueDeProdutos.Models;

namespace EstoqueDeProdutos.Repositories.Interfaces
{
    public interface IControleEstoqueRepository
    {
        Task<ControleEstoque> CadastraControleEstoque(ControleEstoque controleEstoque);
        Task<List<ControleEstoque>> ListaControleEstoque();
        Task<List<ControleEstoque>> RecuperaControleEstoquePorId(int id);
    }
}

