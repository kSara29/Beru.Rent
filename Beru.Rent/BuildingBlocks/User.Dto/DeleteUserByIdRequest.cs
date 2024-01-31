using System.Text.Json.Serialization;

namespace User.Dto;

public record DeleteUserByIdRequest
{
    [JsonPropertyName("id")]
    public required string Id { get; init; }
}