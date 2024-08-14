
namespace TeledockBackAPI.Model
{
public interface IRepoBase<T> where T : class
{
    void Add(T objModel);
    void AddRange(IEnumerable<T> objModel);
    T? GetId(int id);
    Task<T?> GetIdAsync(int id);
    IEnumerable<T> GetAll();
    Task<IEnumerable<T>> GetAllAsync();
    void Update(T objModel);
    void Remove(T objModel);
    void Dispose();
}
}