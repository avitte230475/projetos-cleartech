using EstoqueDeProdutos.Data.Dtos;
using EstoqueDeProdutos.Models;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueDeProdutos.Repositories.Interfaces
{
    public interface IProdutoRepository
    {
        Task<Produto> CadastraProduto(Produto produto);
        Task<List<Produto>> ListaProdutos();
        Task<Produto> RecuperaProdutoPorId(int id);
        Task<Produto> DeletaProduto(int id);
        Task<Produto> EditaProduto(Produto produtoAtualizar);
    }
}
