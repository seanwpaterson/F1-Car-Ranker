using F1CarRankingShared.Entities;
using F1CarRankingData.Contexts;
using F1CarRankingData.Repositories.Base;
using F1CarRankingData.Repositories.Interfaces;

namespace F1CarRankingData.Repositories.Implementations;

public class CarRepository : BaseRepository<Car>, ICarRepository
{
    public CarRepository(AppDbContext context) : base(context)
    {
    }
}