using F1CR.Domain.Abstractions;

namespace F1CR.Domain.Cars;

public sealed class Car : Entity
{
    public Car(Guid id,
        Name name,
        Team team,
        YearRange years,
        List<Variation> variations,
        EloScore currentScore,
        Image image,
        Description description) 
        : base(id)
    {
        Name = name;
        Team = team;
        Years = years;
        Variations = variations;
        CurrentScore = currentScore;
        Image = image;
        Description = description;
    }

    public Name Name { get; private set; }

    public Team Team { get; private set; }

    public YearRange Years { get; private set; }

    public List<Variation>? Variations { get; private set; }

    public EloScore CurrentScore { get; private set; }

    public Image Image { get; private set; }

    public Description Description { get; private set; }
}