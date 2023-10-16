using Microsoft.EntityFrameworkCore;
using SuperHeroApi.Model;

namespace SuperHeroApi.Data
{
    public class DataContext : DbContext
    {
        public DbSet<SuperHero> SuperHero { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=superherodb;Trusted_Connection=true;TrustServerCertificate=true;");
        }

    }
}
