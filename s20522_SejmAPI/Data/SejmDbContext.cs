namespace s20522_SejmAPI.Data;

using Microsoft.EntityFrameworkCore;
using s20522_SejmAPI.Data.Entities;

public class SejmDbContext : DbContext
{
    public SejmDbContext(DbContextOptions<SejmDbContext> options) : base(options) { }

    public DbSet<Polityk> Politycy { get; set; } = null!;
    public DbSet<Partia> Partie { get; set; } = null!;
    public DbSet<Przynaleznosc> Przynaleznosci { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Przynaleznosc>()
            .HasOne(p => p.Polityk)
            .WithMany(pol => pol.Przynaleznosci)
            .HasForeignKey(p => p.PolitykId);

        modelBuilder.Entity<Przynaleznosc>()
            .HasOne(p => p.Partia)
            .WithMany(par => par.Przynaleznosci)
            .HasForeignKey(p => p.PartiaId);
        
    }
    
}