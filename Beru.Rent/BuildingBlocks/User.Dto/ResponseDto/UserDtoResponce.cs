using System.Text.Json.Serialization;

namespace User.Dto.ResponseDto;

public class UserDtoResponce
{
    [JsonPropertyName("userid")] public string? UserId { get; set; }
    [JsonPropertyName("firstname")] public string? FirstName { get; set; }
    [JsonPropertyName("lastname")] public string? LastName { get; set; }
    [JsonPropertyName("username")] public string? UserName { get; set; }
    [JsonPropertyName("iin")] public string? Iin { get; set; }
    [JsonPropertyName("mail")] public string? Mail { get; set; }
    [JsonPropertyName("phone")] public string? Phone { get; set; }
}