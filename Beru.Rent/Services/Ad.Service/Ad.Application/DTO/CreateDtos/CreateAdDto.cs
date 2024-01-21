using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;

namespace Ad.Api.DTO;

[Serializable]
public record CreateAdDto(
    [property: JsonPropertyName("userId")]string UserId,
    [property: JsonPropertyName("title")]string Title,
    [property: JsonPropertyName("description")]string Description,
    [property: JsonPropertyName("extraConditions")]string ExtraConditions,
    [property: JsonPropertyName("deposit")]bool NeededDeposit,
    [property: JsonPropertyName("minDeposit")]decimal MinDeposit,
    [property: JsonPropertyName("price")]decimal Price,
    [property: JsonPropertyName("categoryId")]Guid CategoryId,
    [property: JsonPropertyName("timeUnitId")]Guid TimeUnitId,
    [property: JsonPropertyName("contractTypeId")]int ContractType,
    [property: JsonPropertyName("addressExtraId")]Guid? AddressExtraId,
    [property: JsonPropertyName("addressExtraId")]string Address,
    [property: JsonPropertyName("tags")]string Tags,
    [property: JsonPropertyName("files")] List<IFormFile> Files);
