namespace ChallangeMottu.Application.UseCase;

public interface IMotoService
{
    Task<IEnumerable<MotoDto>> ListarMotosAsync(string? status = null);
    Task<MotoDto?> BuscarPorIdAsync(Guid id);
    Task<MotoDto> CriarAsync(CreateMotoDto dto);
    Task<bool> AtualizarAsync(Guid id, UpdateMotoDto dto);
    Task<bool> DeletarAsync(Guid id);
}