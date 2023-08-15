using CasgemMicroservice.Services.Cargo.DataAccess.Concrete;

namespace CasgemMicroservice.Services.Cargo.DataAccess.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly CargoContext _context;

    public Repository(CargoContext context)
    {
        _context = context;
    }

    public void Insert(T entity)
    {
        _context.Add(entity);
        _context.SaveChanges();
    }

    public void Update(T entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(T entity)
    {
        _context.Remove(entity);
        _context.SaveChanges();
    }

    public List<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public T? GetById(int id)
    {
        return _context.Set<T>().Find(id);
    }
}