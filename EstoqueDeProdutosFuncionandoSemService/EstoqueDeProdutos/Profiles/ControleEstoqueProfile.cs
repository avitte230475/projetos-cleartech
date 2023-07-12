using AutoMapper;
using EstoqueDeProdutos.Data.Dtos;
using EstoqueDeProdutos.Models;

namespace EstoqueDeProdutos.Profiles;

public class ControleEstoqueProfile : Profile
{
    public ControleEstoqueProfile()
    {

        CreateMap<CreateControleEstoqueDto, ControleEstoque>();
        CreateMap<ControleEstoque, ReadControleEstoqueDto>();
        CreateMap<UpdateControleEstoqueDto, ControleEstoque>();
    }
}


