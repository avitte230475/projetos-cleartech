using AutoMapper;
using EstoqueDeProdutos.Data.Dtos;
using EstoqueDeProdutos.Data;
using EstoqueDeProdutos.Models;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueDeProdutos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ControleEstoqueController : ControllerBase
    {
        private ProdutoContext _context;
        private IMapper _mapper;

        public ControleEstoqueController(ProdutoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CadastraEstoque(CreateControleEstoqueDto controleEstoqueDto)
        {
            ControleEstoque controleEstoque = _mapper.Map<ControleEstoque>(controleEstoqueDto);
            _context.ControleEstoque.Add(controleEstoque);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaControleEstoquePorId), new { id = controleEstoque.Id }, controleEstoque);
        }
        [HttpGet]
        public IEnumerable<ReadControleEstoqueDto> ListaControleEstoque()
        {
            return _mapper.Map<List<ReadControleEstoqueDto>>(_context.ControleEstoque); 
            
        }

        [HttpGet("RecuperaControleEstoquePorId/{id}")]
        public IActionResult RecuperaControleEstoquePorId(int id)
        {
            var controleEstoque = _context.ControleEstoque.FirstOrDefault(controleEstoque => controleEstoque.Id == id);
            if (controleEstoque == null) return NotFound();
            var controleEstoqueDto = _mapper.Map<ReadControleEstoqueDto>(controleEstoque);
            return Ok(controleEstoqueDto);
        }
    }
}
