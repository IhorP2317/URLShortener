namespace URLShortener.Domain.Models;

public class ShortenUrl: BaseEntity
{

    public string FullUrl { get; set; } = null!;
    public string Shorten { get; set; } = null!;
}