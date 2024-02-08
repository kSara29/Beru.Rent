using System.Text.Json.Serialization;

namespace User.Dto.ResponseDto;

public class UserDtoResponce
{
    [JsonPropertyName("userId")] public string? UserId { get; set; }
    [JsonPropertyName("firstName")] public string? FirstName { get; set; }
    [JsonPropertyName("lastName")] public string? LastName { get; set; }
    [JsonPropertyName("userName")] public string? UserName { get; set; }
    [JsonPropertyName("iin")] public string? Iin { get; set; }
    [JsonPropertyName("mail")] public string? Mail { get; set; }
    [JsonPropertyName("phone")] public string? Phone { get; set; }
}