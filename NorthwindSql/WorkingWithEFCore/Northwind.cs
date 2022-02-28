using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;
namespace Ifinfo.shared
{
    public class Northwind : DbContext
    {
        public DbSet<Category> Categories {get;set;}  = null!;
        public DbSet<Product> Products {get;set;} = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "Northwind.db");
            optionsBuilder.UseLazyLoadingProxies().UseSqlite($"Filename={path}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
            .Property(category  => category.CategoryName)
            .IsRequired()
            .HasMaxLength(15);
            
            modelBuilder.Entity<Product>()
            .Property(product => product.Cost)
            .HasConversion<double>();
        }
    }
}