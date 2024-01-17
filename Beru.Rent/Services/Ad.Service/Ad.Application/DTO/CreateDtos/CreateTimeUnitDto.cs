using System.Text.Json.Serialization;

namespace Ad.Application.DTO.CreateDtos;

public record CreateTimeUnitDto
{
    [property: JsonPropertyName("title")] public string? Title { get; set; }
    [property: JsonPropertyName("duration")] public TimeSpan Duration { get; set; }
}