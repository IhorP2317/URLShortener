using System.ComponentModel.DataAnnotations;

namespace URLShortener.Domain.Models;

public class UrlViewModel
{

    [Required]
    [RegularExpression(@"^(?:https?://)?(?:www\.)?[\w\-\.]+\.\w{2,}(?:\.\w{2,})?(?:[\w\-._/?=#&%]*?)$")]
    public string Url { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;
}