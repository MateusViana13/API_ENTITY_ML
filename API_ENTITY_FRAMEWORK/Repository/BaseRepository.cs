using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace API_ENTITY_FRAMEWORK.Repository;

public class BaseRepository<TDbcontext, TClass> : IBaseRepository<TDbcontext, TClass> where TDbcontext : DbContext where TClass : class
{
    private readonly TDbcontext _context;
    private readonly DbSet<TClass> _dbSet;

    public BaseRepository(TDbcontext context)
    {
        _context = context;
        _dbSet = _context.Set<TClass>();
    }

    public async Task<TClass> AddAsync(TClass entity)
    {
        await _dbSet.AddAsync(entity);
        return entity;
    }

    public void Update(TClass entity)
    {
        _dbSet.Update(entity);
    }

    public void Remove(TClass entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task<TClass> FindAsync(int id)
    {
        return (await _dbSet.FindAsync(id))!;
    }

    public async Task<TClass> GetAsync(Expression<Func<TClass, bool>> predicate)
    {
        return (await _dbSet.FirstOrDefaultAsync(predicate))!;
    }

    public async Task<List<TClass>> GetListAsync(Expression<Func<TClass, bool>> predicate)
    {
        return (await _dbSet.Where(predicate).ToListAsync())!;
    }

    public async Task<List<TClass>> GetListAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<List<TClass>> GetAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
    
    public async Task AddRangeAsync(List<TClass> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    public bool Exists(Expression<Func<TClass, bool>> predicate)
    {
        return _dbSet.Any(predicate);
    }
}