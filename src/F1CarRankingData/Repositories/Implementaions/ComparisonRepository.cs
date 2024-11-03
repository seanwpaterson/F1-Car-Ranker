using F1CarRankingData.Contexts;
using F1CarRankingData.Repositories.Base;
using F1CarRankingData.Repositories.Interfaces;
using F1CarRankingShared.Entities;

namespace F1CarRankingData.Repositories.Implementations;

public class ComparisonRepository : BaseRepository<Comparison>, IComparisonRepository
{
    public ComparisonRepository(AppDbContext context) : base(context)
    {
    }
}