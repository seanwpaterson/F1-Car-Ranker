using F1CarRankingCore.Models;
using F1CarRankingData.Contexts;

namespace F1CarRankingData.Repositories;

public class TeamRepository : BaseRepository<Team>, ITeamRepository
{
    public TeamRepository(AppDbContext context) : base(context)
    {
    }
}