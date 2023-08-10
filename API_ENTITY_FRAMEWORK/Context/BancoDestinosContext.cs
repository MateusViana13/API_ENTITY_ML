using API_ENTITY_FRAMEWORK.Models.Banco_Destinos;
using Microsoft.EntityFrameworkCore;

namespace API_ENTITY_FRAMEWORK.Context;

public class BancoDestinosContext : DbContext
{
    public DbSet<Destino> Destinos { get; set; }
    public DbSet<PontoTuristico> PontoTuristicos { get; set; }
    public DbSet<PontoTuristicoReview> PontoTuristicoReviews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=students.db");
    }
}

