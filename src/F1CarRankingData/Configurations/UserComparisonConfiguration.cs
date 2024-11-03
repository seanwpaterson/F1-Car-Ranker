using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using F1CarRankingShared.Entities;

namespace F1CarRankingData.Configurations
{
    public class UserComparisonConfiguration : IEntityTypeConfiguration<UserComparison>
    {
        public void Configure(EntityTypeBuilder<UserComparison> builder)
        {
            ConfigureRelationships(builder);
        }

        private void ConfigureRelationships(EntityTypeBuilder<UserComparison> builder)
        {
            builder
                .HasOne(uc => uc.User)
                .WithMany(u => u.UserComparisons)
                .HasForeignKey(uc => uc.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(uc => uc.Comparison)
                .WithMany()
                .HasForeignKey(uc => uc.ComparisonId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}