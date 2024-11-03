namespace F1CarRankingShared.Entities;

public class User
{
    public int Id { get; set; }
    public string UserIdentifier { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // Navigation Property
    public ICollection<UserComparison> UserComparisons { get; set; } = new List<UserComparison>();
}