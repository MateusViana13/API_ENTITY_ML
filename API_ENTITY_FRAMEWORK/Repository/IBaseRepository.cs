using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace API_ENTITY_FRAMEWORK.Repository;

public interface IBaseRepository<TDbContext, TClass> where TClass : class where TDbContext : DbContext
{
    Task<TClass> AddAsync(TClass entity);
    Task AddRangeAsync(List<TClass> entities);
    void Update(TClass entity);
    void Remove(TClass entity);
    Task<TClass> FindAsync(int id);
    Task<TClass> GetAsync(Expression<Func<TClass, bool>> predicate);
    Task<List<TClass>> GetListAsync(Expression<Func<TClass, bool>> predicate);
    Task<List<TClass>> GetListAsync();
    Task<List<TClass>> GetAsync();
    Task SaveChangesAsync();
    bool Exists(Expression<Func<TClass, bool>> predicate);
}
