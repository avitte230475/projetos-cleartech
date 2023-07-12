using EstoqueDeProdutos.Data.Dtos;
using EstoqueDeProdutos.Models;
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
    public async Task<IActionResult> CadastraProduto(CreateProdutoDto produtoDto)
    {
        ReadProdutoDto readDto = await _produtoService.CadastraProduto(produtoDto);
        return CreatedAtAction(nameof(RecuperaProdutoPorId), new { id = readDto.Id }, readDto);
    }

    [HttpGet]
    public async Task<IActionResult> ListarProdutos()
    {
        List<ReadProdutoDto> readDto = await _produtoService.ListaProdutos();
        if(readDto != null) return Ok(readDto);
        return NotFound();
        
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> RecuperaProdutoPorId(int id)
    {
        Produto produto = await _produtoService.RecuperaProdutoPorId(id);
        if (produto != null) return Ok(produto);
        return NotFound();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditaProduto(int id, UpdateProdutoDto produtoDto)
    {
        UpdateProdutoDto produto = await _produtoService.EditaProduto(id, produtoDto);
        if (produto != null) return Ok(produto);
        return NotFound();


    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletaProduto(int id)
    {
        var produto = await _produtoService.DeletaProduto(id);
        if (produto != null) return Ok();
        return NoContent();
    }
}


