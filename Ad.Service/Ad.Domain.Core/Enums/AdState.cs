using System.ComponentModel.DataAnnotations;

namespace Ad.Domain.Core.Enums;

public enum AdState
{
    [Display(Name = "Автивен")]
    Active,
    [Display(Name = "На проверке")]
    Waiting,
    [Display(Name = "Не активен")]
    Archive
}