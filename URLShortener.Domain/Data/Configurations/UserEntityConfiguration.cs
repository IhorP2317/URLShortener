using Microsoft.EntityFrameworkCore.Metadata.Builders;
using URLShortener.Bussiness;
using URLShortener.Domain.Models;

namespace URLShortener.Domain.Data.Configurations;

public class UserEntityConfiguration:BaseEntityConfiguration<User>
{
    private readonly AdminSeedData _adminSeedData;

    public UserEntityConfiguration(AdminSeedData adminSeedData)
    {
        _adminSeedData = adminSeedData;
    } 
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);
        var adminUser = new User
        {
            Id = _adminSeedData.Id,
            Email = _adminSeedData.Email,
            Password = _adminSeedData.Password,
            Role = Enum.Parse<Role>(_adminSeedData.Role),
            CreatedOn = DateTime.Now,
            CreatedBy = null
        };
        builder.HasData(new List<User> { adminUser });
    }
}