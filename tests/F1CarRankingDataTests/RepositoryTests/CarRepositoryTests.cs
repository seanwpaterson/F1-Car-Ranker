using F1CarRankingData.Contexts;
using F1CarRankingData.Repositories.Implementations;
using F1CarRankingShared.Entities;
using Microsoft.EntityFrameworkCore;

namespace F1CarRankingDataTests.RepositoryTests;

public class CarRepositoryTests : IDisposable
{
    private readonly AppDbContext _context;
    private readonly CarRepository _carRepository;

    public CarRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: $"CarRankingTestDb_{Guid.NewGuid()}")
            .Options;

        _context = new AppDbContext(options);

        _context.Cars.AddRange(new List<Car>
        {
            new Car { Id = 1, Name = "Ferrari F1-75", Year = 2022, TeamId = 1, EloScore = 1000 },
            new Car { Id = 2, Name = "Mercedes W13", Year = 2022, TeamId = 2, EloScore = 1000 },
            new Car { Id = 3, Name = "McLaren MCL36", Year = 2023, TeamId = 3, EloScore = 1000 }
        });
        _context.SaveChanges();

        _carRepository = new CarRepository(_context);
    }

    // Dispose method to clean up resources after tests
    public void Dispose()
    {
        _context.Dispose();
    }
}