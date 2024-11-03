using F1CarRankingCore.Models;
using F1CarRankingData.Contexts;
using F1CarRankingData.Repositories.Base;
using F1CarRankingData.Repositories.Interfaces;

namespace F1CarRankingData.Repositories.Implementations;

public class UserComparisonRepositoy : BaseRepository<UserComparison>, IUserComparisonRepository
{
    public UserComparisonRepositoy(AppDbContext context) : base(context)
    {
    }
}