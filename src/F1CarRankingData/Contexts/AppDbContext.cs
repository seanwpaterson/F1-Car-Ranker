using Microsoft.EntityFrameworkCore;
using F1CarRankingCore.Models;
using F1CarRankingData.Configurations;

namespace F1CarRankingData.Contexts
{
    public class AppDbContext : DbContext
    {
        // Constructor accepting DbContextOptions for dependency injection
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSet properties for each entity
        public DbSet<Car> Cars { get; set; }
        public DbSet<Comparison> Comparisons { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserComparison> UserComparisons { get; set; }

        // Configuring the model relationships
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ComparisonConfiguration());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new CarConfiguration());
            modelBuilder.ApplyConfiguration(new UserComparisonConfiguration());
        }
    }
}
