using AutoMapper;
using EstoqueDeProdutos.Data;
using EstoqueDeProdutos.Data.Dtos;
using EstoqueDeProdutos.Models;
using EstoqueDeProdutos.Repositories;
using EstoqueDeProdutos.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

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
        public UpdateProdutoDto EditaProduto(int id, UpdateProdutoDto produtoDto)
        {
            Produto produto = _mapper.Map<Produto>(produtoDto);
            return _mapper.Map<UpdateProdutoDto>(produtoDto);
        }
        public ReadProdutoDto DeletaProduto(int id)
        {
            var produto = _produtoRepository.DeletaProduto(id);
            return null;
        }
    }
 }

