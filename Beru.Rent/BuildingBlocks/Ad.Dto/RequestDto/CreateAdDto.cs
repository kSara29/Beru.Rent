using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;

namespace Ad.Dto.CreateDtos;

[Serializable]
public class CreateAdDto()
{
    [property: JsonPropertyName("userId")] public string? UserId { get; set; }
    [property: JsonPropertyName("title")]public string Title { get; set; }
    [property: JsonPropertyName("description")]public string Description { get; set; }
    [property: JsonPropertyName("extraConditions")]
    public string? ExtraConditions { get; set; }
    [property: JsonPropertyName("neededDeposit")]public bool? NeededDeposit { get; set; }
    [property: JsonPropertyName("minDeposit")]public decimal? MinDeposit { get; set; }
    [property: JsonPropertyName("price")]public decimal Price { get; set; }
    [property: JsonPropertyName("categoryId")]public Guid CategoryId { get; set; }
    [property: JsonPropertyName("timeUnitId")]public Guid TimeUnitId { get; set; }
    [property: JsonPropertyName("contractTypeId")]public int ContractType { get; set; }
    [property: JsonPropertyName("addressExtraId")]public Guid? AddressExtraId { get; set; }
    [property: JsonPropertyName("addressExtra")]public string Address { get; set; }
    [property: JsonPropertyName("tags")]public string Tags { get; set; }
   // [property: JsonPropertyName("files")] public List<IFormFile> Files{ get; set; }
}

