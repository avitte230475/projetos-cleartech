using EstoqueDeProdutos.Models;

namespace EstoqueDeProdutos.Repositories.Interfaces
{
    public interface IControleEstoqueRepository
    {
        ControleEstoque CadastraEstoque(ControleEstoque controleEstoque);
        IEnumerable<ControleEstoque> ListaControleEstoque();
        ControleEstoque RecuperaControleEstoquePorId(int id);
        
    }
}
