using ChallangeMottu.Domain;

namespace ChallangeMottu.Application.UseCase;

public interface IUsuarioService
{
    Task<UsuarioDto?> ObterPorIdAsync(Guid id);
    Task<IEnumerable<UsuarioDto>> ListarTodosAsync();
    Task<UsuarioDto> CriarAsync(CreateUsuarioDto dto);
    Task<UsuarioDto?> AtualizarAsync(Guid id, UpdateUsuarioDto dto);
    Task<bool> DeletarAsync(Guid id);
}
