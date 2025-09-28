using AutoMapper;
using ChallangeMottu.Domain;

namespace ChallangeMottu.Application.Mappings;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        // Usuario -> UsuarioDto
        CreateMap<Usuario, UsuarioDto>();

        // UsuarioCreateDto -> Usuario
        CreateMap<CreateUsuarioDto, Usuario>();

        // UsuarioUpdateDto -> Usuario
        CreateMap<UpdateUsuarioDto, Usuario>();

        // Moto -> MotoResumoDto
        CreateMap<Moto, MotoResumoDto>();
    }
}