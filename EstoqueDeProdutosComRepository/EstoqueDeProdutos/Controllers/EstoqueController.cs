using AutoMapper;
using EstoqueDeProdutos.Data;
using EstoqueDeProdutos.Data.Dtos;
using EstoqueDeProdutos.Models;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueDeProdutos.Controllers;

[ApiController]
[Route("[controller]")]
public class EstoqueController : Controller
{
    private ProdutoContext _context;
    private IMapper _mapper;
   // public int TotalEstoque { get; set; }
    //public int qtidadeEstoque { get; set; }
    public EstoqueController(ProdutoContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaQuantidadeEstoque(CreateEstoqueDto estoqueDto)
    {
        Estoque estoque = _mapper.Map<Estoque>(estoqueDto);
        _context.ControleEstoque.Add(estoque);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaEstoquePorId), new { id = estoque.Id }, estoque);
    }

    [HttpGet]
    public IEnumerable<ReadEstoqueDto> ListaEstoque([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadEstoqueDto>>(_context.ControleEstoque.Skip(skip).Take(take));

    }
    
    [HttpGet("recuperarEstoquePorId/{id}")]
    public IActionResult RecuperaEstoquePorId(int id)
    {
        var estoque = _context.ControleEstoque.FirstOrDefault(estoque => estoque.Id == id);
        if (estoque == null) return NotFound();
        var estoqueDto = _mapper.Map<ReadEstoqueDto>(estoque);
        return Ok(estoqueDto);
    }
    /*
    [HttpGet("baixaEstoque/{id}")]
    public int BaixaEstoque(int quantidadeEstoque, int id)
    {
        var estoque = _context.ControleEstoque.FirstOrDefault(estoque => estoque.Id == id);
        //if (estoque == null) return NotFound();
        var estoqueDto = _mapper.Map<ReadEstoqueDto>(estoque);
        if (TotalEstoque - qtidadeEstoque >= 0)
            TotalEstoque -= qtidadeEstoque;

        return TotalEstoque;
    }
    */
}
