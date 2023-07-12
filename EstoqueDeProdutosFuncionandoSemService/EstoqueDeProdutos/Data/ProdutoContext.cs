using EstoqueDeProdutos.Models;
using Microsoft.EntityFrameworkCore;

namespace EstoqueDeProdutos.Data;

public class ProdutoContext : DbContext
{
    public ProdutoContext(DbContextOptions<ProdutoContext> opts)
        : base(opts)
    {
        
    }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<ControleEstoque> ControleEstoque { get; set; }
}
