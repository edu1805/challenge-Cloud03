using AutoMapper;
using ChallangeMottu.Application;
using ChallangeMottu.Domain;

namespace hallangeMottu.Application.Mappings;

public class Motoprofile : Profile
{
    public Motoprofile()
    {
        CreateMap<Moto, MotoDto>().ReverseMap();

        CreateMap<LocalizacaoAtual, LocalizacaoAtualDto>().ReverseMap();
        CreateMap<CriarLocalizacaoAtualDto, LocalizacaoAtual>();
    }
}