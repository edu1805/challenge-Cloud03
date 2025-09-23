using System.Linq.Expressions;
using ChallangeMottu.Domain;
using ChallangeMottu.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChallangeMottu.Infrastructure.Persistence;

public class MotoRepository : IMotoRepository
{
    private readonly ChallangeMottuContext _context;

    public MotoRepository(ChallangeMottuContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Moto>> GetAllAsync()
    {
        return await _context.Motos.ToListAsync();
    }

    public async Task<Moto?> GetByIdAsync(int id)
    {
        return await _context.Motos.FindAsync(id);
    }

    public async Task<IEnumerable<Moto>> FindAsync(Expression<Func<Moto, bool>> predicate)
    {
        return await _context.Motos.Where(predicate).ToListAsync();
    }

    public async Task AddAsync(Moto moto)
    {
        await _context.Motos.AddAsync(moto);
    }

    public void Update(Moto moto)
    {
        _context.Motos.Update(moto);
    }

    public void Delete(Moto moto)
    {
        _context.Motos.Remove(moto);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}