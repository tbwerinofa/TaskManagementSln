using Microsoft.EntityFrameworkCore;
using TaskManagament.Domain.Common;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Persistence.DatabaseContext;

namespace TaskManagement.Persistence.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    protected readonly TaskDatabaseContext _context;

    public GenericRepository(TaskDatabaseContext context)
    {
        _context = context;
    }
    public async Task<T> CreateAsync(T entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task DeleteAsync(T entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<T>> GetAsync()
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<T> UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return entity;
    }
}
