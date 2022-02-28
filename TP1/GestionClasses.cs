using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;

namespace Ifinfo.Shared
{
    public class GestionClasses : DbContext
    {
        public DbSet<Classes> Classes {get;set;} = null!;
        public DbSet<Eleves> Eleves {get;set;} = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "GestionClasses.db");
            optionsBuilder.UseLazyLoadingProxies().UseSqlite($"Filename={path}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Classes>()
            .Property(classe => classe.NomClasse)
            .IsRequired()
            .HasMaxLength(45);

            modelBuilder.Entity<Eleves>()
            .Property(eleve => eleve.NomEleve)
            .IsRequired()
            .HasMaxLength(45);
        }
    }
}