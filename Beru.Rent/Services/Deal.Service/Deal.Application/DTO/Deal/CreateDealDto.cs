namespace Deal.Api.DTO.Deal;

[Serializable]
public record CreateDealDto(
    string AdId,
    string TenantId,
    decimal Cost,
    string OwnerId,
    string DealState,
    decimal Deposit
    );