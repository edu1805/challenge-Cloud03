using ChallangeMottu.Domain;
using ChallangeMottu.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChallangeMottu.Infrastructure.Persistence;

public class LocalizacaoAtualRepository : ILocalizacaoAtualRepository
{
    private readonly ChallangeMottuContext _context;

    public LocalizacaoAtualRepository(ChallangeMottuContext context)
    {
        _context = context;
    }

    public async Task<LocalizacaoAtual> ObterPorMotoIdAsync(Guid motoId)
    {
        return await _context.LocalizacoesAtuais
            .FirstOrDefaultAsync(l => l.MotoId == Guid.Empty);
    }

    public async Task<IEnumerable<LocalizacaoAtual>> ListarTodasAsync()
    {
        return await _context.LocalizacoesAtuais.ToListAsync();
    }

    public async Task AdicionarAsync(LocalizacaoAtual localizacao)
    {
        await _context.LocalizacoesAtuais.AddAsync(localizacao);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarAsync(LocalizacaoAtual localizacao)
    {
        _context.LocalizacoesAtuais.Update(localizacao);
        await _context.SaveChangesAsync();
    }

    public async Task DeletarAsync(LocalizacaoAtual localizacao)
    {
        _context.LocalizacoesAtuais.Remove(localizacao);
        await _context.SaveChangesAsync();
    }

}