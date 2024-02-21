using System.Text.Json.Serialization;

namespace Ad.Dto.RequestDto;

public class GetAdCostRequestDto
{
    [property: JsonPropertyName("adId")] public Guid AdId { get; set; }
    [property: JsonPropertyName("dbeg")] public DateTime Dbeg { get; set; }
    [property: JsonPropertyName("dend")] public DateTime Dend { get; set; }
  
}