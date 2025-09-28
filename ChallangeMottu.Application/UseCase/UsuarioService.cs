using AutoMapper;
using ChallangeMottu.Domain;
using ChallangeMottu.Domain.Interfaces;

namespace ChallangeMottu.Application.UseCase;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IMapper _mapper;

    public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
    {
        _usuarioRepository = usuarioRepository;
        _mapper = mapper;
    }

    public async Task<UsuarioDto?> ObterPorIdAsync(Guid id)
    {
        var usuario = await _usuarioRepository.ObterPorIdAsync(id);
        return usuario == null ? null : _mapper.Map<UsuarioDto>(usuario);
    }

    public async Task<IEnumerable<UsuarioDto>> ListarTodosAsync()
    {
        var usuarios = await _usuarioRepository.ListarTodosAsync();
        return _mapper.Map<IEnumerable<UsuarioDto>>(usuarios);
    }

    public async Task<UsuarioDto> CriarAsync(CreateUsuarioDto dto)
    {
        var usuario = _mapper.Map<Usuario>(dto);
        await _usuarioRepository.AdicionarAsync(usuario);
        return _mapper.Map<UsuarioDto>(usuario);
    }

    public async Task<UsuarioDto?> AtualizarAsync(Guid id, UpdateUsuarioDto dto)
    {
        var usuario = await _usuarioRepository.ObterPorIdAsync(id);
        if (usuario == null)
            return null;

        // Atualizar os campos
        usuario.AtualizarDados(dto.Nome, dto.Email);

        await _usuarioRepository.AtualizarAsync(usuario);
        return _mapper.Map<UsuarioDto>(usuario);
    }

    public async Task<bool> DeletarAsync(Guid id)
    {
        var usuario = await _usuarioRepository.ObterPorIdAsync(id);
        if (usuario == null)
            return false;

        await _usuarioRepository.DeletarAsync(usuario);
        return true;
    }
}