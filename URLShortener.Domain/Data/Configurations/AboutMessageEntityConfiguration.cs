using Microsoft.EntityFrameworkCore.Metadata.Builders;
using URLShortener.Bussiness;
using URLShortener.Domain.Models;

namespace URLShortener.Domain.Data.Configurations;

public class AboutMessageEntityConfiguration:BaseEntityConfiguration<AboutMessage>
{
    private readonly AboutMessageSeedData _aboutMessageSeedData;

    public AboutMessageEntityConfiguration(AboutMessageSeedData aboutMessageSeedData)
    {
        _aboutMessageSeedData = aboutMessageSeedData;
    }
    public override void Configure(EntityTypeBuilder<AboutMessage> builder)
    {
        base.Configure(builder);
        var about = new AboutMessage
        {
            Id = _aboutMessageSeedData.Id,
            Message = _aboutMessageSeedData.Message
        };
        builder.HasData(new List<AboutMessage> { about });
    }
}