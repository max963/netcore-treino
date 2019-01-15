using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using StoreOfBuild.Domain.Products;
using StoreOfBuild.Domain.Sales;

namespace StoreOfBuild.Data
{
    public class ApplicationDbContext : DbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){

        }
    }
}