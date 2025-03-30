using TaskManagament.Domain.Common;

namespace TaskManagement.Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T> GetByIdAsync(int id);
    Task<IReadOnlyList<T>> GetAsync();
    Task<T> CreateAsync(T entity);

    Task<T> UpdateAsync(T entity);
    Task DeleteAsync(T entity);

}
