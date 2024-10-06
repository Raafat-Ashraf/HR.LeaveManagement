using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain.Common;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories;

public class GenericRepository<T>(HrDatabaseContext hrDatabaseContext) : IGenericRepository<T> where T : BaseEntity
{
    protected readonly HrDatabaseContext _hrDatabaseContext = hrDatabaseContext;

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _hrDatabaseContext.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _hrDatabaseContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(T entity)
    {
        await _hrDatabaseContext.Set<T>().AddAsync(entity);
        await _hrDatabaseContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _hrDatabaseContext.Entry(entity).State = EntityState.Modified;
        await _hrDatabaseContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _hrDatabaseContext.Set<T>().Remove(entity);
        await _hrDatabaseContext.SaveChangesAsync();
    }
}
