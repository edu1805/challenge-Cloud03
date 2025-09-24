using ChallangeMottu.Domain;
using ChallangeMottu.Domain.Interfaces;

namespace ChallangeMottu.Application.UseCase;

public class LocalizacaoAtualService
{
    private readonly ILocalizacaoAtualRepository _localizacaoRepo;

    public LocalizacaoAtualService(ILocalizacaoAtualRepository localizacaoRepo)
    {
        _localizacaoRepo = localizacaoRepo;
    }

    public async Task<LocalizacaoAtual?> ObterPorMotoIdAsync(Guid motoId)
    {
        return await _localizacaoRepo.ObterPorMotoIdAsync(motoId);
    }

    public async Task<IEnumerable<LocalizacaoAtual>> ListarTodasAsync()
    {
        return await _localizacaoRepo.ListarTodasAsync();
    }

    public async Task AdicionarAsync(LocalizacaoAtual localizacao)
    {
        // não permitir duas localizações ativas para a mesma moto
        var existente = await _localizacaoRepo.ObterPorMotoIdAsync(localizacao.MotoId);
        if (existente != null)
            throw new InvalidOperationException("Já existe uma localização para esta moto.");

        await _localizacaoRepo.AdicionarAsync(localizacao);
    }

    public async Task AtualizarAsync(LocalizacaoAtual localizacao)
    {
        await _localizacaoRepo.AtualizarAsync(localizacao);
    }

    public async Task DeletarAsync(Guid motoId)
    {
        var existente = await _localizacaoRepo.ObterPorMotoIdAsync(motoId);
        if (existente == null)
            throw new KeyNotFoundException("Localização não encontrada para esta moto.");

        await _localizacaoRepo.DeletarAsync(existente);
    }
}