using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using F1CarRankingShared.Entities;

namespace F1CarRankingData.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            ConfigureRelationships(builder);
            SeedData(builder);   
        }

        private void ConfigureRelationships(EntityTypeBuilder<Car> builder)
        {
            builder.HasOne(c => c.Team)
                .WithMany(t => t.Cars)
                .HasForeignKey(c => c.TeamId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void SeedData(EntityTypeBuilder<Car> builder)
        {
            builder.HasData(
                new Car 
                { 
                    Id = 1, 
                    Name = "Ferrari F1-75", 
                    Year = 2022, 
                    TeamId = 1, 
                    EloScore = 1000,
                    ImageUrl = "https://cdn-1.motorsport.com/images/amp/0L1nbOV2/s6/ferrari-f1-75-1.jpg"
                },
                new Car 
                {
                    Id = 2, 
                    Name = "Mercedes W13", 
                    Year = 2022, 
                    TeamId = 2, 
                    EloScore = 1000,
                    ImageUrl = "https://www.racedepartment.com/attachments/__custom_showroom_1661514507-jpg.594721/"
                },
                new Car 
                { 
                    Id = 3, 
                    Name = "McLaren MCL36", 
                    Year = 2022, 
                    TeamId = 3, 
                    EloScore = 1000,
                    ImageUrl = "https://p.turbosquid.com/ts-thumb/Yn/6chId7/FO/mcl36_000/jpg/1647874568/1920x1080/fit_q87/f1c71587d84b0f18b047a2ee7d2bf6906f5bf30e/mcl36_000.jpg"
                }
            );
        }
    }
}