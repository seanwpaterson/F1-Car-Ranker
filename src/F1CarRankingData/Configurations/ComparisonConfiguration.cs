using F1CarRankingCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1CarRankingData.Configurations
{
    public class ComparisonConfiguration : IEntityTypeConfiguration<Comparison>
    {
        public void Configure(EntityTypeBuilder<Comparison> builder)
        {
            ConfigureRelationships(builder);
        }

        private void ConfigureRelationships(EntityTypeBuilder<Comparison> builder)
        {
            builder
                .HasOne(c => c.Car1)
                .WithMany(car => car.Car1Comparisons)
                .HasForeignKey(c => c.Car1Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.Car2)
                .WithMany(car => car.Car2Comparisons)
                .HasForeignKey(c => c.Car2Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.SelectedCar)
                .WithMany()
                .HasForeignKey(c => c.SelectedCarId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}