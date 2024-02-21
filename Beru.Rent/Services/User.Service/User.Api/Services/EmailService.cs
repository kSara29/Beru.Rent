using System.Text;
using Newtonsoft.Json;
using Notification.Dto.RequestDto;

namespace User.Api.Services;

public class EmailService(IHttpClientFactory httpClientFactory)
{
    
    public async Task SendEmailAsync(string email, string subject, string message)
    {
        using var client = httpClientFactory.CreateClient();
        var dto = new SendMessageRequestDto
        {
            Email = email,
            Subject = subject,
            Message = message
        };
        var jsonContent = JsonConvert.SerializeObject(dto);
        var contentRequest = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        var result = await client.PostAsync("notification/send", contentRequest);
        if (result.IsSuccessStatusCode)
        {
            
        }
        else
        {
            
        }
    }
}