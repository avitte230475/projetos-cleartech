using EstoqueDeProdutos.Data.Dtos;
using EstoqueDeProdutos.Models;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueDeProdutos.Repositories.Interfaces
{
    public interface IProdutoRepository
    {
        Produto CadastraProduto(Produto produto);
        IEnumerable<Produto> ListaProdutos();
        Produto RecuperaProdutoPorId(int id);
        Produto EditaProduto(int id, Produto produto);
        Produto DeletaProduto(int id);
        Produto EditaProduto(Produto produtoAtualizar);
    }
}
