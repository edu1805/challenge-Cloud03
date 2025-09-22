using System.Linq.Expressions;

namespace ChallangeMottu.Domain.Interfaces;

public interface IMotoRepository
{
    Task<IEnumerable<Moto>> GetAllAsync();
    Task<Moto?> GetByIdAsync(int id);
    Task<IEnumerable<Moto>> FindAsync(Func<Moto, bool> predicate);
    Task AddAsync(Moto moto);
    void Update(Moto moto);
    void Delete(Moto moto);
    Task SaveChangesAsync();
}