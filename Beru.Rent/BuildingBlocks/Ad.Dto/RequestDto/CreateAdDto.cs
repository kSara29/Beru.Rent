using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;

namespace Ad.Dto.CreateDtos;

[Serializable]
public class CreateAdDto()
{
    [property: JsonPropertyName("userId")] public string? UserId { get; set; }
    [property: JsonPropertyName("title")]public string Title { get; set; }
    [property: JsonPropertyName("description")]public string Description { get; set; }
    [property: JsonPropertyName("extraConditions")] public string? ExtraConditions { get; set; }
    [property: JsonPropertyName("neededDeposit")]public bool? NeededDeposit { get; set; }
    [property: JsonPropertyName("minDeposit")]public decimal? MinDeposit { get; set; }
    [property: JsonPropertyName("price")]public decimal Price { get; set; }
    [property: JsonPropertyName("categoryId")]public Guid CategoryId { get; set; }
    [property: JsonPropertyName("timeUnitId")]public Guid TimeUnitId { get; set; }
    [property: JsonPropertyName("contractTypeId")]public int ContractType { get; set; }
    [property: JsonPropertyName("tags")]public string Tags { get; set; }
    [property: JsonPropertyName("files")] public List<IFormFile> Files{ get; set; }
   [property: JsonPropertyName("latitude")] public string? Latitude { get; set; }
   [property: JsonPropertyName("longitude")] public string? Longitude { get; set; }
   [property: JsonPropertyName("street")] public required string Street { get; set; }
   [property: JsonPropertyName("house")] public string? House { get; set; }
   [property: JsonPropertyName("floor")] public byte? Floor { get; set; }
   [property: JsonPropertyName("apartment")] public string? Apartment { get; set; }
   [property: JsonPropertyName("country")] public required string Country { get; set; }
   [property: JsonPropertyName("city")] public required string City { get; set; }
   [property: JsonPropertyName("region")] public required string Region { get; set; }
   [property: JsonPropertyName("postindex")] public string? PostIndex { get; set; }
   
   public Guid? AddressExtraId { get; set; }

}

