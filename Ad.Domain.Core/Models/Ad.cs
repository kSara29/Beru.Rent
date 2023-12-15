using Ad.Domain.Core.Enums;
using Ad.Domain.Core.Models.Common;

namespace Ad.Domain.Core.Models;

public class Ad : Entity
{
    public string UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string? ExtraConditions { get; set; }
    public bool Deposit { get; set; }
    public decimal? MinDeposit { get; set; }
    public AdState State { get; set; }
    public decimal Price { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string CategoryId { get; set; }
    public Category Category { get; set; }
    public string TimeUnitId { get; set; }
    public TimeUnit TimeUnit { get; set; }
    public string ContractTypeId { get; set; }
    public ContractType ContractType { get; set; }
    public string AddressExtraId { get; set; }
    public AddressExtra AddressExtra { get; set; }
}