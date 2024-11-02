using F1CarRankingData.Repositories;

namespace F1CarRankingAPI.Extensions;

public static class ServiceExtensions
{
    public static void AddRepositoryServices(this IServiceCollection services)
    {
        services.AddScoped<ITeamRepository, TeamRepository>();
        services.AddScoped<ICarRepository, CarRepository>();
    }
}