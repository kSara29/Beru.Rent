namespace Deal.Dto.Deal;

[Serializable]
public record CreateDealDto(
    Guid AdId,
    Guid TenantId,
    decimal Cost,
    Guid OwnerId,
    string DealState,
    decimal Deposit
    );