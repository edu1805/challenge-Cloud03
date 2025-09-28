using ChallangeMottu.Domain;
using ChallangeMottu.Infrastructure.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;

namespace ChallangeMottu.Infrastructure.Persistence;

public class ChallangeMottuContext(DbContextOptions<ChallangeMottuContext> options) : DbContext(options)
{
    public DbSet<Moto> Motos { get; set; }
    public DbSet<LocalizacaoAtual> LocalizacoesAtuais { get; set; }
    public DbSet<Usuario> Usuario { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MotoMapping());
        modelBuilder.ApplyConfiguration(new LocalizacaoAtualMapping());
        modelBuilder.ApplyConfiguration(new UsuarioMapping());
    }
}