using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F1CarRankingCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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