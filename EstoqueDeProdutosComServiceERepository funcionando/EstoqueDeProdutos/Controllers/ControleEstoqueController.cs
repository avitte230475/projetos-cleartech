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
        public IActionResult CadastraEstoque(CreateControleEstoqueDto controleEstoqueDto)
        {
            ReadControleEstoqueDto readDto = _controleEstoqueService.CadastraEstoque(controleEstoqueDto);
            return CreatedAtAction(nameof(RecuperaControleEstoquePorId), new { id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult ListaControleEstoque()
        {
            List<ReadControleEstoqueDto> readDto = _controleEstoqueService.ListaControleEstoque();
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpGet("RecuperaControleEstoquePorId/{id}")]
        public IActionResult RecuperaControleEstoquePorId(int id)
        {
            ReadControleEstoqueDto readDto = _controleEstoqueService.RecuperaControleEstoquePorId(id);
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }
    }
}
