using AutoMapper;
using EstoqueDeProdutos.Data;
using EstoqueDeProdutos.Data.Dtos;
using EstoqueDeProdutos.Models;

namespace EstoqueDeProdutos.Services
{
    public class ControleEstoqueService
    {
        private ProdutoContext _context;
        private IMapper _mapper;

        public ControleEstoqueService(ProdutoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadControleEstoqueDto CadastraEstoque(CreateControleEstoqueDto controleEstoqueDto)
        {
            ControleEstoque controleEstoque = _mapper.Map<ControleEstoque>(controleEstoqueDto);
            _context.ControleEstoque.Add(controleEstoque);
            _context.SaveChanges();
            return _mapper.Map<ReadControleEstoqueDto>(controleEstoque);
        }

        public List<ReadControleEstoqueDto> ListaControleEstoque()
        {
            //Aqui a lógica também precisa listar o total de estoque.
            return _mapper.Map<List<ReadControleEstoqueDto>>(_context.ControleEstoque);
        }

        public ReadControleEstoqueDto RecuperaControleEstoquePorId(int id)
        {
            var controleEstoque = _context.ControleEstoque.FirstOrDefault(controleEstoque => controleEstoque.Id == id);
            var controleEstoqueDto = _mapper.Map<ReadControleEstoqueDto>(controleEstoque);
            return controleEstoqueDto;
        }
    }
}
