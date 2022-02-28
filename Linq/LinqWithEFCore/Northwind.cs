using Microsoft.EntityFrameworkCore;
namespace Ifinfo.shared
{
    public class Northwind : DbContext
    {
        public DbSet<Category> Categories {get;set;}  = null!;
        public DbSet<Product> Products {get;set;} = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "Northwind.db");
            optionsBuilder.UseSqlite($"Filename={path}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<Product>()
            .Property(product => product.UnitPrice)
            .HasConversion<double>();
        }
    }
}