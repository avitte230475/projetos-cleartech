using AutoMapper;
using EstoqueDeProdutos.Data;
using EstoqueDeProdutos.Data.Dtos;
using EstoqueDeProdutos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace EstoqueDeProdutos.Services
{
    public class ProdutoService
    {
        private ProdutoContext _context;
        private IMapper _mapper;

        public ProdutoService(ProdutoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadProdutoDto CadastraProduto(CreateProdutoDto produtoDto)
        {
            Produto produto = _mapper.Map<Produto>(produtoDto);
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return _mapper.Map<ReadProdutoDto>(produto);
        }

        public List<ReadProdutoDto>ListaProdutos()
        {
            //Aqui a lógica também precisa listar o total de estoque.
            return _mapper.Map<List<ReadProdutoDto>>(_context.Produtos);
        }

        public ReadProdutoDto RecuperaProdutoPorId(int id)
        {
            var produtoDto = (
            from produto in _context.Produtos
            where produto.Id == id
            join controleEstoque in _context.ControleEstoque
            on produto.Id equals controleEstoque.ProdutoId
            into controleEstoqueAgrupado
            select new ReadProdutoDto
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Status = produto.Status,
                Valor = produto.Valor,
                TotalEstoque = controleEstoqueAgrupado
                .Sum(x => x.QtdEntrada) - controleEstoqueAgrupado.Sum(x => x.QtdSaida)
            }).FirstOrDefault();
            return produtoDto;
        }

        public UpdateProdutoDto EditaProduto(int id, UpdateProdutoDto produtoDto)
        {
            var produto = _context.Produtos.FirstOrDefault(produto => produto.Id == id);
            if (produto == null)
                return null;
            produto.Nome = produtoDto.Nome;
            produto.Status = produtoDto.Status;
            produto.Valor = produtoDto.Valor;

            _context.Update(produto);
            _context.SaveChanges();
            return produtoDto;
            
        }

        public ReadProdutoDto DeletaProduto(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(produto => produto.Id == id);
           
            _context.Remove(produto);
            _context.SaveChanges();
            return null;

             
        }
    }
 }

