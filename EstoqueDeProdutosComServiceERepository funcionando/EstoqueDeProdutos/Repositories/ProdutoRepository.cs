using EstoqueDeProdutos.Data;
using EstoqueDeProdutos.Models;
using EstoqueDeProdutos.Repositories.Interfaces;

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
                    Id = produto.Id,
                    Nome = produto.Nome,
                    Status = produto.Status,
                    Valor = produto.Valor,
                    TotalEstoque = controleEstoqueAgrupado
                    .Sum(x => x.QtdEntrada) - controleEstoqueAgrupado.Sum(x => x.QtdSaida)
                }).ToList();
            return prod.ToList();
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
                    TotalEstoque = controleEstoqueAgrupado.Sum(x => x.QtdEntrada) - controleEstoqueAgrupado.Sum(x => x.QtdSaida)
                }
            ).FirstOrDefault();

            return prod;
            }
        //public Produto EditaProduto(Produto produto)
        //{
        //    _context.Update(produto);
        //    _context.SaveChanges();
        //    return produto;

        //}

        public Produto EditaProduto(Produto produtoAtualizar)
        {
            _context.Update(produtoAtualizar);
            _context.SaveChanges();
            return produtoAtualizar;
        }
        public Produto EditaProduto(int id, Produto produto)
        {
            return produto;
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

