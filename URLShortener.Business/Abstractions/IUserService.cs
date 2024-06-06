using System.Security.Claims;
using URLShortener.Domain.Models;

namespace URLShortener.Bussiness.Interfaces;

public interface IUserService
{
    public IQueryable<User> GetAll();
    public Task<User> CreateAsync(User model);
    public Task<ClaimsIdentity> Register(RegisterViewModel model);
    public Task<ClaimsIdentity> Login(LoginViewModel model);
}