using EstoqueDeProdutos.Data;
using EstoqueDeProdutos.Models;
using EstoqueDeProdutos.Repositories.Interfaces;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySqlConnector;

namespace EstoqueDeProdutos.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ProdutoContext _context;
        
        public ProdutoRepository(ProdutoContext context)
        {
            _context = context;
            
        }

        public async Task<Produto> CadastraProduto(Produto produto)
        {
            var prod = _context.Produtos.FirstOrDefaultAsync();
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<List<Produto>> ListaProdutos()
        {
            var prod = await (
                from produto in _context.Produtos
                join controleEstoque in _context.ControleEstoque
                on produto.Id equals controleEstoque.ProdutoId
                into controleEstoqueAgrupado
                select new Produto
                {
                    Id = produto.Id,
                    Nome = produto.Nome,
                    Status = produto.Status,
                    Valor = produto.Valor,
                    TotalEstoque = controleEstoqueAgrupado
                    .Sum(x => x.QtdEntrada) - controleEstoqueAgrupado.Sum(x => x.QtdSaida)
                }).ToListAsync();
            return prod.ToList();

        }

        public async Task<Produto> RecuperaProdutoPorId(int id)
        {
            var prod = await(
                from produto in _context.Produtos
                where produto.Id == id
                join controleEstoque in _context.ControleEstoque
                    on produto.Id equals controleEstoque.ProdutoId
                    into controleEstoqueAgrupado
                select new Produto
                {
                    Id = produto.Id,
                    Nome = produto.Nome,
                    Status = produto.Status,
                    Valor = produto.Valor,
                    TotalEstoque = controleEstoqueAgrupado.Sum(x => x.QtdEntrada) - controleEstoqueAgrupado.Sum(x => x.QtdSaida)
                }
            ).FirstOrDefaultAsync();

            return prod;
            }

        public async Task<Produto> EditaProduto(Produto produtoAtualizar)
        {
            _context.Update(produtoAtualizar);
            await _context.SaveChangesAsync();
            return produtoAtualizar;
        }
        public async Task<Produto> DeletaProduto(int id)
        {
            var produto = await _context.Produtos.FirstOrDefaultAsync(produto => produto.Id == id);
            _context.Remove(produto);
            await _context.SaveChangesAsync();
            return null;
        }
    }
}

