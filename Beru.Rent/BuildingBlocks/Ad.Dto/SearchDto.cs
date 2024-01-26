using System.Text.Json.Serialization;

namespace Ad.Dto;

public record SearchDto
(
    [property: JsonPropertyName("Advertisement")]string UserId
    );