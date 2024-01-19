namespace Deal.Api.DTO.Deal;

[Serializable]
public record CreateDealDto(
    Guid AdId,
    Guid TenantId,
    decimal Cost,
    Guid OwnerId,
    string DealState,
    decimal Deposit
    );