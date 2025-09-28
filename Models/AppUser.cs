using Microsoft.AspNetCore.Identity;

public class AppUser : IdentityUser
{
    public string Role { get; set; } = "User"; 
    public string FirstName { get; set; } = string.Empty; 
    public string LastName { get; set; } = string.Empty;     
}