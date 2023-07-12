using AutoMapper;
using EstoqueDeProdutos.Data.Dtos;
using EstoqueDeProdutos.Models;

namespace EstoqueDeProdutos.Profiles;

public class ProdutoProfile : Profile
{
    public ProdutoProfile()
    {
        CreateMap<CreateProdutoDto, Produto>();
        CreateMap<UpdateProdutoDto, Produto>();
        CreateMap<Produto, UpdateProdutoDto>();
        CreateMap<Produto, ReadProdutoDto>();
    }

}


