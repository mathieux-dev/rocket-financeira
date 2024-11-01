using Microsoft.EntityFrameworkCore;
using RocketFinanceira.Application.Interfaces.Repositories;
using RocketFinanceira.Infra.Data;
using System.Linq.Expressions;

namespace RocketFinanceira.Infra.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly RocketFinanceiraDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(RocketFinanceiraDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<T> GetByIdAsync(string id) => 
        await _dbSet.FindAsync(id);

    public async Task<IEnumerable<T>> GetAllAsync() => 
        await _dbSet.ToListAsync();

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate) => 
        await _dbSet.Where(predicate).ToListAsync();

    public void Add(T entity) => _dbSet.Add(entity);

    public void Update(T entity) => _dbSet.Update(entity);

    public void Remove(T entity) => _dbSet.Remove(entity);
}
