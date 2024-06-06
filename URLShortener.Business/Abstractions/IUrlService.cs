using URLShortener.Domain.Models;

namespace URLShortener.Bussiness.Interfaces;

public interface IUrlService
{
    public Task<ShortenUrl> Create(UrlViewModel model);
    public IQueryable<ShortenUrl> GetAll();
    public ShortenUrl GetById(int id);
    public Task Remove(int id);
    public int Decode(string encoded);
}