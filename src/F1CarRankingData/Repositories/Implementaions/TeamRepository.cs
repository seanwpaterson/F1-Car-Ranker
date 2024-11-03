using F1CarRankingCore.Models;
using F1CarRankingData.Contexts;
using F1CarRankingData.Repositories.Base;
using F1CarRankingData.Repositories.Interfaces;

namespace F1CarRankingData.Repositories.Implementations;

public class TeamRepository : BaseRepository<Team>, ITeamRepository
{
    public TeamRepository(AppDbContext context) : base(context)
    {
    }
}