namespace F1CarRankingCore.Services.Base;

public interface IBaseService<T> where T : class
{
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    void RemoveAsync(T entity);
    void RemoveRangeAsync(IEnumerable<T> entities);
    void UpdateAsync(T entity);
}