using AutoMapper;
using ChallangeMottu.Application;
using ChallangeMottu.Domain;

namespace hallangeMottu.Application.Mappings;

public class LocalizacaoAtualProfile : Profile
{
    public LocalizacaoAtualProfile()
    {
        CreateMap<LocalizacaoAtual, LocalizacaoAtualDto>();
        CreateMap<CriarLocalizacaoAtualDto, LocalizacaoAtual>();
        CreateMap<AtualizarLocalizacaoAtualDto, LocalizacaoAtual>();
    }
}