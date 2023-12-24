using System.ComponentModel.DataAnnotations;

namespace Deal.Domain.Enums;

public enum BookingState
{
    [Display(Name = "Подтверждено")]  Accept,
    [Display(Name = "Отказано")]      Decline,
    [Display(Name = "В очереди")]     InQueue
}