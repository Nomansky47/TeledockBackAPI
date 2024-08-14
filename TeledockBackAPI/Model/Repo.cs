
using System.Data;
namespace TeledockBackAPI.Model
{

public class Repo<T> : IRepoBase<T> where T : class
{

    protected readonly Context _context;

    public Repo(Context context)
    {
        _context=context;
    }

    public void Add(T model)
    {
        _context.Set<T>().Add(model);
        _context.SaveChanges();
    }

    public void AddRange(IEnumerable<T> model)
    {
        _context.Set<T>().AddRange(model);
        _context.SaveChanges();
    }

    public T? GetId(int id)
    {
        return _context.Set<T>().Find(id);
    }

    public async Task<T?> GetIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await Task.Run(() => _context.Set<T>());
    }


    public void Update(T objModel)
    {
       // _context.Entry(objModel).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Remove(T objModel)
    {
        _context.Set<T>().Remove(objModel);
        _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}

}