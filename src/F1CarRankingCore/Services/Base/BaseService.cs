using F1CarRankingData.Repositories.Base;

namespace F1CarRankingCore.Services.Base;

public class BaseService<T> : IBaseService<T> where T : class
{
    protected readonly IBaseRepository<T> _repository;

    public BaseService(IBaseRepository<T> repository)
    {
        _repository = repository;
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task AddAsync(T entity)
    {
        await _repository.AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _repository.AddRangeAsync(entities);
    }

    public void RemoveAsync(T entity)
    {
        _repository.Remove(entity);
    }

    public void RemoveRangeAsync(IEnumerable<T> entities)
    {
        _repository.RemoveRange(entities);
    }

    public void UpdateAsync(T entity)
    {
        _repository.Update(entity);
    }
}