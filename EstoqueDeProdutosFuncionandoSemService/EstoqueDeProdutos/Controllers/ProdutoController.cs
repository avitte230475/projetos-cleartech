using AutoMapper;
using EstoqueDeProdutos.Data;
using EstoqueDeProdutos.Data.Dtos;
using EstoqueDeProdutos.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueDeProdutos.Controllers;

[ApiController]
[Route("[controller]")]

public class ProdutoController : ControllerBase
{
    private ProdutoContext _context;
    private IMapper _mapper;

    public ProdutoController(ProdutoContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CadastraProduto(CreateProdutoDto produtoDto)
    {
        Produto produto = _mapper.Map<Produto>(produtoDto);
        _context.Produtos.Add(produto);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaProdutoPorId), new { id = produto.Id }, produto);
    }
    
    [HttpGet]
    public IEnumerable<ReadProdutoDto> ListaProdutos() 
    {
        var produtoDto = (
            from produto in _context.Produtos
            join controleEstoque in _context.ControleEstoque
            on produto.Id equals controleEstoque.ProdutoId
            into controleEstoqueAgrupado
            select new ReadProdutoDto
            {
                Nome = produto.Nome,
                Status = produto.Status,
                Valor = produto.Valor,
                TotalEstoque = controleEstoqueAgrupado
                .Sum(x => x.QtdEntrada) - controleEstoqueAgrupado.Sum(x => x.QtdSaida)
            }).ToList();
        return produtoDto;

    }

    [HttpGet("{id}")]
    public IActionResult RecuperaProdutoPorId(int id)
    {
        var produtoDto = (
            from produto in _context.Produtos
            where produto.Id == id
            join controleEstoque in _context.ControleEstoque
            on produto.Id equals controleEstoque.ProdutoId
            into controleEstoqueAgrupado
            select new ReadProdutoDto
            {
                Nome = produto.Nome,
                Status = produto.Status,
                Valor = produto.Valor,
                TotalEstoque = controleEstoqueAgrupado
                .Sum(x => x.QtdEntrada) - controleEstoqueAgrupado.Sum(x => x.QtdSaida)
            }).FirstOrDefault();
        if (produtoDto == null) return NotFound();
        return Ok(produtoDto);
    }


    [HttpPut("{id}")]
    public IActionResult EditaProduto(int id, [FromBody]UpdateProdutoDto produtoDto)
    {
        var produto = _context.Produtos.FirstOrDefault(produto => produto.Id == id);
        if (produto == null) return NotFound();
        _mapper.Map(produtoDto, produto);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaProduto(int id)
    {
        var produto = _context.Produtos.FirstOrDefault(produto => produto.Id == id);
        if (produto == null) return NotFound();
        _context.Remove(produto);
        _context.SaveChanges();
        return NoContent();
    }
}
