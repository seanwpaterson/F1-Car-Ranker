using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using F1CarRankingShared.Entities;

namespace F1CarRankingData.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {   
            SeedData(builder);
        }

        private void SeedData(EntityTypeBuilder<Team> builder)
        {
            builder.HasData(
                new Team { Id = 1, Name = "Ferrari", Country = "Italy" },
                new Team { Id = 2, Name = "Mercedes", Country = "Germany" },
                new Team { Id = 3, Name = "McLaren", Country = "United Kingdom" }
            );
        }
    }
}