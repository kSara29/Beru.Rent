using System.ComponentModel.DataAnnotations;

namespace User.Dto.RequestDto;

public class CreateUserDto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string UserName { get; set; }
    public required string Iin { get; set; }
    public required string Mail { get; set; }
    public required string Phone { get; set; }
    
    [Required(ErrorMessage = "Поле обязательно для заполнения")]
    public string Password { get; set; }

    [Compare("Password", ErrorMessage = "Пароли не совпадают")]
    public string ConfirmPassword { get; set; }
    public string? ReturnUrl { get; set; }
}