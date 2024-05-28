namespace TournamentSite.Core.Repositories;

public interface IRepository<T>
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetAsync(int id);
    Task<bool> AnyAsync(int id);
    void Add(T entity);
    void Update(T entity);
    void Remove(T entity);
}
