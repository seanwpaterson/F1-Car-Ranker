namespace F1CarRankingCore.Models;

public class Team
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Country { get; set; } // Optional field for additional info

    // Navigation Property
    public ICollection<Car> Cars { get; set; } = new List<Car>();
}