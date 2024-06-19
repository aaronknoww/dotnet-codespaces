// Interfaces creadas para accesar a las tablas de las bases de datos
public interface IGenericRepository<T> where T : class
{
    // Metodos genericos para cualquier tabla de una base de datos para hacer el CRUD.
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
    Task<T> GetAsync();
    Task<T> GetByIdAsync(int id);

}
