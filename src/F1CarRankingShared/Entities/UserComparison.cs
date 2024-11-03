using System.ComponentModel.DataAnnotations;

namespace F1CarRankingShared.Entities;

public class UserComparison
{
    public int Id { get; set; }

    // Navigation Properties
    public int UserId { get; set; }  // Foreign Key to User
    [Required]
    public User User { get; set; } = null!;
    public int ComparisonId { get; set; }  // Foreign Key to Comparison
    [Required]
    public Comparison Comparison { get; set; } = null!;
}
