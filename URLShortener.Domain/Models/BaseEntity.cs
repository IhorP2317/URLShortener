using System.ComponentModel.DataAnnotations;

namespace URLShortener.Domain.Models;

public class BaseEntity
{
    public int Id { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
}