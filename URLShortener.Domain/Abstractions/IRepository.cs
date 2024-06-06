using URLShortener.Domain.Models;

namespace URLShortener.Domain.Interfaces
{

    public interface IRepository<T> where T : BaseEntity
    {
        public Task<int> SaveChangesAsync();
        public IQueryable<T> GetAll();
        public T Get(int id);
        public void Create(T model);
        public void Remove(T model);
        public void Update(T model);
    }
}