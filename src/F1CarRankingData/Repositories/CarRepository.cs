using F1CarRankingCore.Models;
using F1CarRankingData.Contexts;

namespace F1CarRankingData.Repositories;

public class CarRepository : Repository<Car>, ICarRepository
{
    public CarRepository(AppDbContext context) : base(context)
    {
    }
}