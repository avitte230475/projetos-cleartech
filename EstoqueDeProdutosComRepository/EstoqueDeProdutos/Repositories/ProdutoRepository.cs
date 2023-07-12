using AutoMapper;
using EstoqueDeProdutos.Data;
using EstoqueDeProdutos.Data.Dtos;
using EstoqueDeProdutos.Models;
using EstoqueDeProdutos.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueDeProdutos.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ProdutoContext _context;
        
        public ProdutoRepository(ProdutoContext context)
        {
            _context = context;
        }
        public Produto CadastraProduto(Produto produto)
        {
            Produto prod = _context.Produtos.FirstOrDefault();
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return produto;
        }
        public IEnumerable<Produto> ListaProdutos()
        {
            var prod = (
                from produto in _context.Produtos
                join controleEstoque in _context.ControleEstoque
                on produto.Id equals controleEstoque.ProdutoId
                into controleEstoqueAgrupado
                select new Produto
                {
                    Nome = produto.Nome,
                    Status = produto.Status,
                    Valor = produto.Valor,
                    TotalEstoque = controleEstoqueAgrupado
                    .Sum(x => x.QtdEntrada) - controleEstoqueAgrupado.Sum(x => x.QtdSaida)
                }).ToList();
            return _context.Produtos;
        }
        public Produto RecuperaProdutoPorId(int id)
        {
            var prod = (
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
                TotalEstoque = controleEstoqueAgrupado
                .Sum(x => x.QtdEntrada) - controleEstoqueAgrupado.Sum(x => x.QtdSaida)
            });
            return _context.Produtos.FirstOrDefault(c => c.Id == id);
        }

        public Produto EditaProduto(int id, Produto produto)
        {
            var prod = _context.Produtos.FirstOrDefault(produto => produto.Id == id);
            if (produto == null)
                return null;
            produto.Nome = produto.Nome;
            produto.Status = produto.Status;
            produto.Valor = produto.Valor;
            _context.Update(produto);
            _context.SaveChanges();
            return prod;
        }
        public Produto DeletaProduto(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(produto => produto.Id == id);
            _context.Remove(produto);
            _context.SaveChanges();
            return null;
        }

        


        
        
        
    }
}

