using System.Text;
using System.Text.Json;
using Common;
using User.Dto;

namespace Bff.Application.Maping;

public class UserServiceMaping
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
    
    public async Task<ResponseModel<UserDtoResponce>> UserResponceModelMaping(HttpResponseMessage responseMessage)
    {
        if (!responseMessage.IsSuccessStatusCode)
        {
            var responceFailed = new ResponseModel<UserDtoResponce>(new ResponseError
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
        var userDto = JsonSerializer.Deserialize<UserDtoResponce>(jsonString);

        if (userDto is null)
        {
            var responceModel = new ResponseModel<UserDtoResponce>(new ResponseError
            {
                Code = "email",
                Message = "Юзер не найден"
            })
            {
                Status = ResponseStatus.Failed
            };
            return responceModel;
        };
        
        var responceSuccess = new ResponseModel<UserDtoResponce>(userDto)
        {
            Status = ResponseStatus.Success
        };
                    
        return responceSuccess;
    }
}