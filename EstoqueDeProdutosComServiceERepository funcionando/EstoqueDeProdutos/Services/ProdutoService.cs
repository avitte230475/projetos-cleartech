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

        public ReadProdutoDto CadastraProduto(CreateProdutoDto produtoDto)
        {
            Produto produto = _mapper.Map<Produto>(produtoDto);
            _produtoRepository.CadastraProduto(produto);
            return _mapper.Map<ReadProdutoDto>(produto);
        }

        public List<ReadProdutoDto> ListaProdutos()
        {
            var produtos = _produtoRepository.ListaProdutos();
            return _mapper.Map<List<ReadProdutoDto>>(produtos);
        }

        public ReadProdutoDto RecuperaProdutoPorId(int id)
        {
            var produto = _produtoRepository.RecuperaProdutoPorId(id);
            return _mapper.Map<ReadProdutoDto>(produto);
        }
        [HttpPut("{id}")]
        public UpdateProdutoDto EditaProduto(int id, UpdateProdutoDto produtoDto)
        {
            var prod = _produtoRepository.RecuperaProdutoPorId(id);
            var produtoAtualizar = _mapper.Map(produtoDto, prod);
            _produtoRepository.EditaProduto(produtoAtualizar);
            return produtoDto;
        }

        //public UpdateProdutoDto EditaProduto(int id, UpdateProdutoDto produtoDto)
        //{
        //    var produto = _produtoRepository.RecuperaProdutoPorId(id);
        //    produto.Nome = produtoDto.Nome;
        //    produto.Valor = produtoDto.Valor;
        //    produto.Status = produtoDto.Status;
        //    var prod = _produtoRepository.EditaProduto(id, produto);
        //    return _mapper.Map<UpdateProdutoDto>(produtoDto);

        //}

        public ReadProdutoDto DeletaProduto(int id)
        {
            var produto = _produtoRepository.DeletaProduto(id);
            return null;
        }
    }
}

 

