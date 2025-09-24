namespace ChallangeMottu.Application.UseCase;

public interface IMotoService
{
    Task<IEnumerable<MotoDto>> ListarMotosAsync(string? status = null);
    Task<MotoDto?> BuscarPorIdAsync(int id);
    Task<MotoDto> CriarAsync(CreateMotoDto dto);
    Task<bool> AtualizarAsync(int id, UpdateMotoDto dto);
    Task<bool> DeletarAsync(int id);
}