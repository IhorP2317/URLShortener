using URLShortener.Domain.Data;
using URLShortener.Domain.Interfaces;
using URLShortener.Domain.Models;

namespace URLShortener.Domain.Implementations;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly ApplicationDbContext _dbContext;
    
    public Repository(ApplicationDbContext db)
    {
        _dbContext = db ?? throw new ArgumentNullException(nameof(db));
    }
    
    public void Create(T model)
    {
        _dbContext.Set<T>().Add(model);
    }
    
    public IQueryable<T> GetAll()
    {
        return _dbContext.Set<T>().AsQueryable();
    }
    
    public T Get(int id)
    {
        return _dbContext.Set<T>().FirstOrDefault(x => x.Id == id);
    }
    
    public void Remove(T model)
    {
        _dbContext.Set<T>().Remove(model);
    }
    
    public async Task<int> SaveChangesAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }
    
    public void Update(T model)
    {
        _dbContext.Set<T>().Update(model);
    }
}