using EstoqueDeProdutos.Data;
using EstoqueDeProdutos.Data.Dtos;
using EstoqueDeProdutos.Models;
using EstoqueDeProdutos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EstoqueDeProdutos.Repositories
{
    public class ControleEstoqueRepository : IControleEstoqueRepository
    {
        private readonly ProdutoContext _context;
        public ControleEstoqueRepository(ProdutoContext context)
        {
            _context = context;
        }

        public async Task<ControleEstoque> CadastraControleEstoque(ControleEstoque controleEstoque)
        {
            var controle = _context.ControleEstoque.FirstOrDefaultAsync();
            _context.ControleEstoque.Add(controleEstoque);
            await _context.SaveChangesAsync();
            return controleEstoque;
        }
        public async Task<List<ControleEstoque>> ListaControleEstoque()
        {
            return await _context.ControleEstoque.ToListAsync(); ;
        }
        
        public async Task<List<ControleEstoque>> RecuperaControleEstoquePorId(int produtoId)
        {
            return await _context.ControleEstoque.Where(c => c.ProdutoId == produtoId).ToListAsync();
            
        }
    }
}

