using AutoMapper;
using ChallangeMottu.Application;
using ChallangeMottu.Domain;

namespace ChallangeMottu.Application.Mappings;

public class MotoProfile : Profile
{
    public MotoProfile()
    {
        CreateMap<Moto, MotoDto>().ReverseMap();

        CreateMap<LocalizacaoAtual, LocalizacaoAtualDto>().ReverseMap();
        CreateMap<CriarLocalizacaoAtualDto, LocalizacaoAtual>();
    }
}