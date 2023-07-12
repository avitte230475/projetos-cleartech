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
        public async Task<ReadControleEstoqueDto> CadastraControleEstoque(CreateControleEstoqueDto controleEstoqueDto)
        {
            ControleEstoque controleEstoque = _mapper.Map<ControleEstoque>(controleEstoqueDto);
            await _controleEstoqueRepository.CadastraControleEstoque(controleEstoque);
            return _mapper.Map<ReadControleEstoqueDto>(controleEstoque);

        }
        public async Task<List<ReadControleEstoqueDto>> ListaControleEstoque()
        {
            var controleEstoque = await _controleEstoqueRepository.ListaControleEstoque();
            return _mapper.Map<List<ReadControleEstoqueDto>>(controleEstoque);
        }
        public async Task<List<ReadControleEstoqueDto>> RecuperaControleEstoquePorId(int produtoId)
        {
            List<ControleEstoque> controleEstoque = await _controleEstoqueRepository.RecuperaControleEstoquePorId(produtoId);
            return _mapper.Map<List<ReadControleEstoqueDto>>(controleEstoque);
            
        }
    }
}
