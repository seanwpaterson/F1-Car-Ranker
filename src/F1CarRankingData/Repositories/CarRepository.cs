using F1CarRankingCore.Models;
using F1CarRankingData.Contexts;

namespace F1CarRankingData.Repositories;

public class CarRepository : BaseRepository<Car>, ICarRepository
{
    public CarRepository(AppDbContext context) : base(context)
    {
    }
}