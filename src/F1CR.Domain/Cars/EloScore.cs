namespace F1CR.Domain.Cars;

public record EloScore(
    double Value,
    DateTime? LastUpdated,
    double Delta,
    int? Rank);