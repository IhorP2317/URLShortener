using System.ComponentModel.DataAnnotations;

namespace URLShortener.Domain.Models;

public enum Role
{
    [Display(Name = "User")]
    User,
    [Display(Name = "Admin")]
    Admin
}