using System.Text.Json.Serialization;

namespace Ad.Api.DTO;

[Serializable]
public record CreateAdDto(
    [property: JsonPropertyName("userId")]string UserId,
    [property: JsonPropertyName("title")]string Title,
    [property: JsonPropertyName("description")]string Description,
    [property: JsonPropertyName("extraConditions")]string ExtraConditions,
    [property: JsonPropertyName("deposit")]bool Deposit,
    [property: JsonPropertyName("minDeposit")]decimal MinDeposit,
    [property: JsonPropertyName("price")]decimal Price,
    [property: JsonPropertyName("categoryId")]string CategoryId,
    [property: JsonPropertyName("timeUnitId")]string TimeUnitId,
    [property: JsonPropertyName("contractTypeId")]string ContractTypeId,
    [property: JsonPropertyName("addressExtraId")]string AddressExtraId
    );
