using System.Text.Json.Serialization;

namespace Ad.Application.DTO;

public record SearchDto
(
    [property: JsonPropertyName("Advertisement")]string UserId
    );