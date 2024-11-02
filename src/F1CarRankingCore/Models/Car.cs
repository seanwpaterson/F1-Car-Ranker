using System.ComponentModel.DataAnnotations;

namespace F1CarRankingCore.Models;

public class Car
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Year { get; set; }
    public decimal EloScore { get; set; } = 1000m;
    public string ImageUrl { get; set; } = string.Empty;
    public string AltText { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int SelectionCount { get; set; } = 0;

    // Foreign Key and Navigation Property
    public int TeamId { get; set; }
    [Required]
    public Team Team { get; set; } = null!;

    // Other Navigation Properties
    public ICollection<Comparison> Car1Comparisons { get; set; } = new List<Comparison>();
    public ICollection<Comparison> Car2Comparisons { get; set; } = new List<Comparison>();
}
