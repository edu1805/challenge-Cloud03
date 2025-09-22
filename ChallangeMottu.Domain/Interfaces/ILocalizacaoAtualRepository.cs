namespace ChallangeMottu.Domain.Interfaces;

public interface ILocalizacaoAtualRepository
{
    Task<LocalizacaoAtual> ObterPorMotoIdAsync(int motoId);
    Task<IEnumerable<LocalizacaoAtual>> ListarTodasAsync();
    Task AdicionarAsync(LocalizacaoAtual localizacao);
    Task AtualizarAsync(LocalizacaoAtual localizacao);
    Task DeletarAsync(LocalizacaoAtual localizacao);
}