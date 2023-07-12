using AutoMapper;
using EstoqueDeProdutos.Data;
using EstoqueDeProdutos.Data.Dtos;
using EstoqueDeProdutos.Models;
using EstoqueDeProdutos.Repositories;
using EstoqueDeProdutos.Repositories.Interfaces;

namespace EstoqueDeProdutos.Services
{
    public class ControleEstoqueService
    {
        private readonly IControleEstoqueRepository _controleEstoqueRepository;
        private ProdutoContext _context;
        private IMapper _mapper;
        public ControleEstoqueService(ProdutoContext context, IMapper mapper, IControleEstoqueRepository controleEstoqueRepository)
        {
            _controleEstoqueRepository = controleEstoqueRepository;
            _context = context;
            _mapper = mapper;
        }
        public ReadControleEstoqueDto CadastraEstoque(CreateControleEstoqueDto controleEstoqueDto)
        {
            ControleEstoque controleEstoque = _mapper.Map<ControleEstoque>(controleEstoqueDto);
            _controleEstoqueRepository.CadastraEstoque(controleEstoque);
            return _mapper.Map<ReadControleEstoqueDto>(controleEstoque);

        }
        public List<ReadControleEstoqueDto> ListaControleEstoque()
        {
            var controleEstoque = _controleEstoqueRepository.ListaControleEstoque();
            return _mapper.Map<List<ReadControleEstoqueDto>>(controleEstoque);
        }
        public ReadControleEstoqueDto RecuperaControleEstoquePorId(int id)
        {
            var controleEstoque = _controleEstoqueRepository.RecuperaControleEstoquePorId(id);
            return _mapper.Map<ReadControleEstoqueDto>(controleEstoque);
        }
    }
}
