using API_ENTITY_FRAMEWORK.Models.Banco_Destinos;
using Microsoft.EntityFrameworkCore;

namespace API_ENTITY_FRAMEWORK.Context;

public class BancoDestinosContext : DbContext
{
    public BancoDestinosContext(DbContextOptions<BancoDestinosContext> options) : base(options)
    {}

    public DbSet<Destino> Destinos { get; set; }
    public DbSet<PontoTuristico> PontoTuristicos { get; set; }
    public DbSet<PontoTuristicoReview> PontoTuristicoReviews { get; set; }  

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Destino>()
            .HasMany(d => d.PontosTuristicos)
            .WithOne(p => p.Destino);
        
        modelBuilder.Entity<PontoTuristico>()
            .HasMany(p => p.PontoTuristicoReviews)
            .WithOne(r => r.PontoTuristico);

        modelBuilder.Entity<PontoTuristico>()
            .HasOne(p => p.Destino)
            .WithMany(d => d.PontosTuristicos)
            .HasForeignKey(p => p.DestinoId);

        modelBuilder.Entity<PontoTuristicoReview>()
            .HasOne(r => r.PontoTuristico)
            .WithMany(p => p.PontoTuristicoReviews)
            .HasForeignKey(r => r.PontoTuristicoId);
    }
}

