namespace SharkITTesteTecnico.Infrastructure.Interfaces;

public interface IBaseRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAll();
    Task<T?> GetById(Guid id);
    Task<Guid> Create(T entity);
    Task Update(T entity);
    Task Delete(Guid id);
}
