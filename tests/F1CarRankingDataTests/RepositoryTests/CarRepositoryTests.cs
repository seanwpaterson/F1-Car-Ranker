using F1CarRankingCore.Models;
using F1CarRankingData.Contexts;
using F1CarRankingData.Repositories;
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

    [Fact]
    public async Task GetByIdAsync_ShouldReturnCarWithSpecifiedId()
    {
        // Act
        var result = await _carRepository.GetByIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
        Assert.Equal("Ferrari F1-75", result.Name);
    }

    [Fact]
    public async void GetAllAsync_ShouldReturnListOfAllCars()
    {
        // Given
        var expcted = new List<Car>
        {
            new Car { Id = 1, Name = "Ferrari F1-75", Year = 2022, TeamId = 1, EloScore = 1000 },
            new Car { Id = 2, Name = "Mercedes W13", Year = 2022, TeamId = 2, EloScore = 1000 },
            new Car { Id = 3, Name = "McLaren MCL36", Year = 2023, TeamId = 3, EloScore = 1000 }
        };
    
        // When
        var result = await _carRepository.GetAllAsync();
    
        // Then
        Assert.Equal(3, expcted.Count());
        Assert.Equivalent(expcted, result, true);
    }

    [Fact]
    public async void FindAsync_ShouldReturnListOfCarsThatMatchExpression()
    {
        // Given
        var expcted = new List<Car>
        {
            new Car { Id = 1, Name = "Ferrari F1-75", Year = 2022, TeamId = 1, EloScore = 1000 },
            new Car { Id = 2, Name = "Mercedes W13", Year = 2022, TeamId = 2, EloScore = 1000 }
        };

        // When
        var result = await _carRepository.FindAsync(c => c.Year == 2022);

        // Then
        Assert.Equal(2, result.Count());
        Assert.Equivalent(expcted, result, true);
    }

    [Fact]
    public async Task AddAsync_ShouldAddCar()
    {
        // Arrange
        var newCar = new Car { Id = 4, Name = "Red Bull RB18", Year = 2022, TeamId = 4, EloScore = 1000 };

        // Act
        await _carRepository.AddAsync(newCar);
        await _context.SaveChangesAsync(); // Persist changes

        // Assert
        var result = await _carRepository.GetByIdAsync(newCar.Id);
        Assert.NotNull(result);
        Assert.Equal("Red Bull RB18", result.Name);
        Assert.Equal(2022, result.Year);
    }

    // AddRange
    [Fact]
    public async Task AddRangeAsync_ShouldAddMultipleCars()
    {
        // Arrange: Create a list of new cars to add
        var newCars = new List<Car>
        {
            new Car { Id = 4, Name = "Red Bull RB18", Year = 2022, TeamId = 4, EloScore = 1000 },
            new Car { Id = 5, Name = "Aston Martin AMR22", Year = 2022, TeamId = 5, EloScore = 950 }
        };

        // Act: Call AddRange and save changes
        await _carRepository.AddRangeAsync(newCars);
        await _context.SaveChangesAsync();

        // Assert: Verify that the cars were added to the database
        var result = await _context.Cars.Where(c => newCars.Select(nc => nc.Id).Contains(c.Id)).ToListAsync();
        Assert.Equal(2, result.Count());
        Assert.Contains(result, c => c.Name == "Red Bull RB18");
        Assert.Contains(result, c => c.Name == "Aston Martin AMR22");
    }

    [Fact]
    public async Task Remove_ShouldRemoveCar()
    {
        // Arrange
        var carToRemove = new Car { Id = 4, Name = "Red Bull RB18", Year = 2022, TeamId = 4, EloScore = 1000 };
        await _carRepository.AddAsync(carToRemove);
        await _context.SaveChangesAsync();

        // Act
        _carRepository.Remove(carToRemove);
        await _context.SaveChangesAsync();

        // Assert
        var result = await _carRepository.GetByIdAsync(carToRemove.Id);
        Assert.Null(result); // The car should no longer exist
    }

    // RemoveRange
    [Fact]
    public async Task RemoveRange_ShouldRemoveMultipleCars()
    {
        // Arrange: Seed the database with cars to be removed
        var carsToRemove = new List<Car>
        {
            new Car { Id = 6, Name = "AlphaTauri AT03", Year = 2022, TeamId = 6, EloScore = 900 },
            new Car { Id = 7, Name = "Williams FW44", Year = 2022, TeamId = 7, EloScore = 880 }
        };

        await _carRepository.AddRangeAsync(carsToRemove);
        await _context.SaveChangesAsync();

        // Act: Call RemoveRange and save changes
        _carRepository.RemoveRange(carsToRemove);
        await _context.SaveChangesAsync();

        // Assert: Verify that the cars were removed from the database
        var result = await _context.Cars.Where(c => carsToRemove.Select(cr => cr.Id).Contains(c.Id)).ToListAsync();
        Assert.Empty(result); // Should return an empty list if all were removed
    }

    [Fact]
    public async Task Update_ShouldUpdateCar()
    {
        // Arrange
        var carToUpdate = new Car { Id = 6, Name = "McLaren MCL36", Year = 2022, TeamId = 3, EloScore = 1000 };
        await _carRepository.AddAsync(carToUpdate);
        await _context.SaveChangesAsync();

        // Act
        carToUpdate.Name = "McLaren Updated MCL36";
        carToUpdate.EloScore = 1100;
        _carRepository.Update(carToUpdate);
        await _context.SaveChangesAsync();

        // Assert
        var result = await _carRepository.GetByIdAsync(carToUpdate.Id);

        Assert.NotNull(result);
        Assert.Equal("McLaren Updated MCL36", result.Name);
        Assert.Equal(1100, result.EloScore);
    }

    // Dispose method to clean up resources after tests
    public void Dispose()
    {
        _context.Dispose();
    }
}