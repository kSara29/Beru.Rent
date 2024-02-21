using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace User.Api.Models;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Поле обязательно")]
    public required string FirstName { get; set; }
    
    [Required(ErrorMessage = "Поле обязательно")]
    public required string LastName { get; set; }
    
    [Required(ErrorMessage = "Поле обязательно")]
    [Remote(action: "CheckName", controller: "Validation", ErrorMessage ="Этот никнейм уже занят")]
    public required string UserName { get; set; }
    
    [Required(ErrorMessage = "Поле обязательно")]
    public required string Iin { get; set; }
    
    [Required(ErrorMessage = "Поле обязательно")]
    [Remote(action: "EmailCheck", controller: "Validation", ErrorMessage ="Эта почта уже занята")]
    public required string Email { get; set; }
    
    [Required(ErrorMessage = "Поле обязательно")]
    [Remote(action: "PhoneCheck", controller: "Validation", ErrorMessage ="Этот номер уже занят")]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "Номер телефона должен содержать ровно 10 цифр")]
    public required string Phone { get; set; }
    
    [Required(ErrorMessage = "Поле обязательно")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required(ErrorMessage = "Поле обязательно")]
    [Compare("Password", ErrorMessage = "Пароли не совпадают")]
    [DataType(DataType.Password)]
    [Display(Name = "Подтвердить пароль")]
    public string ConfirmPassword { get; set; }
    
    public string? ReturnUrl { get; set; }
}