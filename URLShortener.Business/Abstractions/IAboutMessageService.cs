using URLShortener.Domain.Models;

namespace URLShortener.Bussiness.Interfaces;

public interface IAboutMessageService
{
    public IQueryable<AboutMessage> GetAll();
    public Task Update(AboutMessage message);
}