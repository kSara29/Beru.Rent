namespace Deal.Api.DTO.Deal;

[Serializable]
public record CreateDealDto(
    Guid AdId,
    Guid TenantId,
    decimal? Cost,
    string OwnerId,
    DateTime dbeg,
    DateTime dend
    );