using F1CarRankingData.Contexts;
using F1CarRankingData.Repositories.Base;
using F1CarRankingData.Repositories.Interfaces;
using F1CarRankingShared.Entities;

namespace F1CarRankingData.Repositories.Implementations;

public class UserComparisonRepositoy : BaseRepository<UserComparison>, IUserComparisonRepository
{
    public UserComparisonRepositoy(AppDbContext context) : base(context)
    {
    }
}