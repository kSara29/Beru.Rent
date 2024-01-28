using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;

namespace Ad.Dto.CreateDtos;

public record CreateFileDto (
    [property:JsonPropertyName("adId")] Guid AdId, 
    [property:JsonPropertyName("file")] IFormFile File
);