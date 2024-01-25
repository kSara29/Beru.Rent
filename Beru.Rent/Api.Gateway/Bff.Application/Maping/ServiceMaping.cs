using System.Text;
using System.Text.Json;
using Common;

namespace Bff.Application.Maping;

public class ServiceMaping<T>
{
    public async Task<HttpResponseMessage> HttpGetConnection(string connectionString)
    {
        using var client = new HttpClient();
        var connection = 
            await client.GetAsync(connectionString);
        return connection;
    }
    
    public async Task<HttpResponseMessage> HttpPostConnection(string connectionString, string content)
    {
        using var client = new HttpClient();
        var contentRequest = new StringContent(content, Encoding.UTF8, "application/json");
        var connection = 
            await client.PostAsync(connectionString, contentRequest);
        return connection;
    }

    public string GetContentString(string content, string contentPropName) => 
        $"{{ \"{contentPropName}\": \"{content}\" }}";
    
    public async Task<ResponseModel<T>> ResponceModelMaping(HttpResponseMessage responseMessage)
    {
        if (!responseMessage.IsSuccessStatusCode)
        {
            var responceFailed = new ResponseModel<T>(new ResponseError
            {
                Code = "server",
                Message = "Что то не так"
            })
            {
                Status = ResponseStatus.Failed
            };
            return responceFailed;
        }
        var jsonString = await responseMessage.Content.ReadAsStringAsync();
        var userDto = JsonSerializer.Deserialize<T>(jsonString);

        if (userDto is null)
        {
            var responceModel = new ResponseModel<T>(new ResponseError
            {
                Code = "email",
                Message = "Юзер не найден"
            })
            {
                Status = ResponseStatus.Failed
            };
            return responceModel;
        };
        
        var responceSuccess = new ResponseModel<T>(userDto)
        {
            Status = ResponseStatus.Success
        };
                    
        return responceSuccess;
    }
}