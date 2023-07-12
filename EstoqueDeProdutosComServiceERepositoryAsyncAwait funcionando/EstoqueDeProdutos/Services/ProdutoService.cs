using AutoMapper;
using EstoqueDeProdutos.Data.Dtos;
using EstoqueDeProdutos.Models;
using EstoqueDeProdutos.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueDeProdutos.Services
{
    public class ProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IControleEstoqueRepository _controleEstoqueRepository;
        private IMapper _mapper;

        public ProdutoService(IMapper mapper, IProdutoRepository produtoRepository, IControleEstoqueRepository controleEstoqueRepository)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
            _controleEstoqueRepository = controleEstoqueRepository;
        }

        public async Task<ReadProdutoDto> CadastraProduto(CreateProdutoDto produtoDto)
        {
            Produto produto = _mapper.Map<Produto>(produtoDto);
            await _produtoRepository.CadastraProduto(produto);
            return _mapper.Map<ReadProdutoDto>(produto);
        }

        public async Task<List<ReadProdutoDto>> ListaProdutos()
        {
            var produtos = await _produtoRepository.ListaProdutos();
            return _mapper.Map<List<ReadProdutoDto>>(produtos);
        }

        public async Task<Produto> RecuperaProdutoPorId(int id)
        {
            var produto = await _produtoRepository.RecuperaProdutoPorId(id);
            return produto;
        }
        [HttpPut("{id}")]
        public async Task<UpdateProdutoDto> EditaProduto(int id, UpdateProdutoDto produtoDto)
        {
            var prod = await _produtoRepository.RecuperaProdutoPorId(id);
            var produtoAtualizar = _mapper.Map(produtoDto, prod);
            _produtoRepository.EditaProduto(produtoAtualizar);
            return produtoDto;
        }

        public async Task<Produto> DeletaProduto(int id)
        {
            var produto = await _produtoRepository.DeletaProduto(id);
            return null;
        }
    }
}

 

