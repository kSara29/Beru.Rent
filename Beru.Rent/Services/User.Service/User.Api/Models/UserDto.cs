namespace Auth.Models;

public class UserDto
{
    public required string UserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? UserName { get; set; }
    public string? Iin { get; set; }
    public string? Mail { get; set; }
    public string? Phone { get; set; }
}