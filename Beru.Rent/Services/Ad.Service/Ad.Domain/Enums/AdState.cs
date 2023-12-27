 
using System.ComponentModel.DataAnnotations;

public enum AdState
{
    [Display(Name = "Автивен")]
    Active,
    [Display(Name = "На проверке")]
    Waiting,
    [Display(Name = "Не активен")]
    Archive
}