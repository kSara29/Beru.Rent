using System.ComponentModel.DataAnnotations;

namespace Deal.Domain.Enums;

public enum DealState
{
    [Display(Name = "Открыто")]  Open,
    [Display(Name = "Закрыто")]  Close,
    [Display(Name = "Спор")]     Dispute,
    [Display(Name = "Владелец_предлагает_закрыть")]     OwnerOffer,
    [Display(Name = "Арендатор_предлагает_закрыть")]     TenantOffer
    
}