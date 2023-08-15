namespace CasgemMicroservice.Services.Cargo.DataAccess.Repository;

public interface IRepository<T> where T : class
{
    void Insert(T entity);
    void Update(T entity);
    void Delete(T entity);
    List<T> GetAll();
    T? GetById(int id);
}