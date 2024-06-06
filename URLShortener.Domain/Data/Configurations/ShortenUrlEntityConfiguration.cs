using Microsoft.EntityFrameworkCore.Metadata.Builders;
using URLShortener.Domain.Models;

namespace URLShortener.Domain.Data.Configurations;

public class ShortenUrlEntityConfiguration:BaseEntityConfiguration<ShortenUrl>
{
    public override void Configure(EntityTypeBuilder<ShortenUrl> builder)
    {
        base.Configure(builder);
    }
}