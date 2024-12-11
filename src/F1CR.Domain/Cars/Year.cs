namespace F1CR.Domain.Cars;

public record YearRange
{
    public YearRange(DateTime startYear, DateTime? endYear)
    {
        if (endYear.HasValue && endYear < startYear)
        {
            throw new ApplicationException("End year cannont be earlier than the start year.");
        }

        StartYear = startYear;
        EndYear = endYear;
    }

    public DateTime StartYear { get; private set; }

    public DateTime? EndYear { get; set; }
}