using System.ComponentModel.DataAnnotations;

namespace URLShortener.Domain.Models;

public class LoginViewModel
{
    [Required]
    [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
    public string Email { get; set; } = null!;

    [Required]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$")]
    public string Password { get; set; } = null!;
}