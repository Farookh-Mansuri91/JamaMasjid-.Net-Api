using Microsoft.EntityFrameworkCore;
using SunniNooriMasjidAPI.Data.MasjidDbContext;
using SunniNooriMasjidAPI.Interfaces;
using System.Linq.Expressions;

namespace SunniNooriMasjidAPI.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly SunniNooriMasjidDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(SunniNooriMasjidDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

    public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

    #nullable disable
    public async Task<T> GetByConditionAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.FirstOrDefaultAsync(predicate);
    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate) => await _dbSet.Where(predicate).ToListAsync();

    public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);
    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    public void Update(T entity) => _dbSet.Update(entity);
    public void Remove(T entity) => _dbSet.Remove(entity);
}
