using System.ComponentModel.DataAnnotations;

namespace F1CarRankingCore.Models;

public class Comparison
{
    public int Id { get; set; }
    public decimal Car1EloBefore { get; set; }
    public decimal Car2EloBefore { get; set; }
    public decimal Car1EloAfter { get; set; }
    public decimal Car2EloAfter { get; set; }
    public DateTime ComparisonTimestamp { get; set; } = DateTime.Now;  // Auto-set timestamp

    // Navigation Properties
    public int Car1Id { get; set; }  // Foreign Key to Car
    [Required]
    public Car Car1 { get; set; } = null!;
    public int Car2Id { get; set; }  // Foreign Key to Car
    [Required]
    public Car Car2 { get; set; } = null!;
    public int? SelectedCarId { get; set; }  // Nullable for selected car
    public virtual Car? SelectedCar { get; set; }
}