using System.ComponentModel.DataAnnotations;

namespace URLShortener.Domain.Models;

public class User : BaseEntity
{
    [Required] 
    public string Email { get; set; } = null!;

    [Required] 
    public string Password { get; set; } = null!;

    public Role Role { get; set; } 
}