namespace User.Api.Services;

public class EmailService(IHttpClientFactory httpClientFactory)
{
    private readonly HttpClient _client = httpClientFactory.CreateClient("Notification");
    public async Task SendEmailAsync(string email, string subject, string message)
    {
        var result = await _client.PostAsJsonAsync("notification/send", message);
        if (result.IsSuccessStatusCode)
        {
           
        }
        else
        {
            
        }
    }
}