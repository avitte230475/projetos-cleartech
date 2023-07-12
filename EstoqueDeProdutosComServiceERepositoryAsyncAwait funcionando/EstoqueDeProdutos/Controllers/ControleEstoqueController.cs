using AutoMapper;
using EstoqueDeProdutos.Data.Dtos;
using EstoqueDeProdutos.Data;
using EstoqueDeProdutos.Models;
using Microsoft.AspNetCore.Mvc;
using EstoqueDeProdutos.Services;
using Microsoft.EntityFrameworkCore;

namespace EstoqueDeProdutos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ControleEstoqueController : ControllerBase
    {
        private ControleEstoqueService _controleEstoqueService;

        public ControleEstoqueController(ControleEstoqueService controleEstoqueService)
        {
            _controleEstoqueService = controleEstoqueService;
        }

        [HttpPost]
        public async Task<IActionResult> CadastraControleEstoque(CreateControleEstoqueDto controleEstoqueDto)
        {
            ReadControleEstoqueDto readDto = await _controleEstoqueService.CadastraControleEstoque(controleEstoqueDto);
            return CreatedAtAction(nameof(RecuperaControleEstoquePorId), new { produtoId = readDto.Id }, readDto);
        }

        [HttpGet]
        public async Task<IActionResult> ListaControleEstoque()
        {
            List<ReadControleEstoqueDto> readDto = await _controleEstoqueService.ListaControleEstoque();
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpGet("RecuperaControleEstoquePorId/{produtoId}")]
        public async Task<IActionResult> RecuperaControleEstoquePorId(int produtoId)
        {
            List<ReadControleEstoqueDto> readDto = await _controleEstoqueService.RecuperaControleEstoquePorId(produtoId);
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }
    }
}
