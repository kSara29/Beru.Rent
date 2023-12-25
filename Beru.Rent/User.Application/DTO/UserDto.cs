namespace User.Application.DTO;

public class UserDto
{
    public required string UserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? UserName { get; set; }
    public string? IIN { get; set; }
    public string? Mail { get; set; }
    public string? Phone { get; set; }
}