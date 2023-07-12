using EstoqueDeProdutos.Data.Dtos;
using EstoqueDeProdutos.Services;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueDeProdutos.Controllers;

[ApiController]
[Route("[controller]")]

public class ProdutoController : ControllerBase
{
    private ProdutoService _produtoService;

    public ProdutoController(ProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    [HttpPost]
    public IActionResult CadastraProduto(CreateProdutoDto produtoDto)
    {
        ReadProdutoDto readDto = _produtoService.CadastraProduto(produtoDto);
        return CreatedAtAction(nameof(RecuperaProdutoPorId), new { id = readDto.Id }, readDto);
    }

    [HttpGet]
    public IActionResult ListaProdutos()
    {
        List<ReadProdutoDto> readDto = _produtoService.ListaProdutos();
        if (readDto != null) return Ok(readDto);
        return NotFound();
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaProdutoPorId(int id)
    {
        ReadProdutoDto readDto = _produtoService.RecuperaProdutoPorId(id);
        if (readDto != null) return Ok(readDto);
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult EditaProduto(int id, [FromBody] UpdateProdutoDto produtoDto)
    {
        UpdateProdutoDto produto = _produtoService.EditaProduto(id, produtoDto);
        if (produto == null) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaProduto(int id)
    {
        ReadProdutoDto produtoDto = _produtoService.DeletaProduto(id);
        if (produtoDto == null) return Ok(produtoDto);
            return NotFound(); 
    }
}


