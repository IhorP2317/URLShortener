namespace URLShortener.Bussiness;

public class AdminSeedData
{
    public int Id { get; set; } 
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Role { get; set; } = null!;
}