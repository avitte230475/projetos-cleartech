using EstoqueDeProdutos.Data;
using EstoqueDeProdutos.Data.Dtos;
using EstoqueDeProdutos.Models;
using EstoqueDeProdutos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EstoqueDeProdutos.Repositories
{
    public class ControleEstoqueRepository : IControleEstoqueRepository
    {
        private readonly ProdutoContext _context;
        public ControleEstoqueRepository(ProdutoContext context)
        {
            _context = context;
        }
        public ControleEstoque CadastraEstoque(ControleEstoque controleEstoque)
        {
            ControleEstoque controle = _context.ControleEstoque.FirstOrDefault();
            _context.ControleEstoque.Add(controleEstoque);
            _context.SaveChanges();
            return controleEstoque;
        }
        public IEnumerable<ControleEstoque> ListaControleEstoque()
        {
            return _context.ControleEstoque;
        }
        public ControleEstoque RecuperaControleEstoquePorId(int id)
        {
            var prod = (
            from produto in _context.Produtos
            where produto.Id == id
            join controleEstoque in _context.ControleEstoque
            on produto.Id equals controleEstoque.ProdutoId
            into controleEstoqueAgrupado
            select new ReadProdutoDto
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Status = produto.Status,
                Valor = produto.Valor,
                TotalEstoque = controleEstoqueAgrupado
                .Sum(x => x.QtdEntrada) - controleEstoqueAgrupado.Sum(x => x.QtdSaida)
            });
            return _context.ControleEstoque.FirstOrDefault(c => c.Id == id);
        }
    }
}
