using ChallangeMottu.Domain;

namespace ChallangeMottu.Application.UseCase;

public interface ILocalizacaoAtualService
{
    Task<LocalizacaoAtual?> ObterPorMotoIdAsync(Guid motoId);
    Task<IEnumerable<LocalizacaoAtual>> ListarTodasAsync();
    Task AdicionarAsync(LocalizacaoAtual localizacao);
    Task AtualizarAsync(LocalizacaoAtual localizacao);
    Task DeletarAsync(Guid motoId);
}