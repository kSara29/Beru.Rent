
using Ad.Domain.Enums;
using Ad.Domain.Models.Common;

namespace Ad.Domain.Models;

public class Advertisement  : Entity
{
    public string UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string? ExtraConditions { get; set; }
    public bool? NeededDeposit { get; set; }
    public decimal? MinDeposit { get; set; }
    public AdState State { get; set; }
    public decimal Price { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
    public Guid TimeUnitId { get; set; }
    public TimeUnit TimeUnit { get; set; }
    public ContractType ContractType { get; set; }
    public Guid? AddressExtraId { get; set; }
    public AddressExtra AddressExtra { get; set; }
    public List<FileModel> Files { get; set; }

    public Advertisement(string userId,
        string title,
        string description,
        string? extraConditions,
        bool neededDeposit,
        decimal? minDeposit,
        decimal price,
        string id,
        Guid categoryId,
        Guid timeUnitId,
        Guid addressExtraId)
    {
        UserId = userId;
        Title = title;
        Description = description;
        ExtraConditions = extraConditions;
        NeededDeposit = neededDeposit;
        MinDeposit = minDeposit;
        Price = price;
        CategoryId = categoryId;
        TimeUnitId = timeUnitId;
        AddressExtraId = addressExtraId;
       
    }

    public Advertisement()
    {
    }
}