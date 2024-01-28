using System.Text;
using Common;
using Newtonsoft.Json;

namespace Bff.Application.Handlers;

public class ServiceHandler<T>
{
    /// <summary>
    /// Создает Url для соединения c query параметрами
    /// </summary>
    /// <param name="jsonUrl">Url указаный в jsonOptions, например "https://localhost:7258/"</param>
    /// <param name="url">Url - адрес эндпоинта удаленного сервера, например: "api/user/getByName?UserName="</param>
    /// <param name="query">query параметр: например для Email передаем только значение Email</param>
    /// <returns>возвращает собраный Url адрес</returns>
    public string CreateConnectionUrlWithQuery(string jsonUrl, string url, string query) =>
        string.Concat(jsonUrl, url, query);
    
    /// <summary>
    /// Создает Url для соединения без query параметров
    /// </summary>
    /// <param name="jsonUrl">Url указаный в jsonOptions, например "https://localhost:7258/"</param>
    /// <param name="url">"api/user/getByName?UserName="</param>
    /// <returns>возвращает собраный Url адрес</returns>
    public string CreateConnectionUrlWithoutQuery(string jsonUrl, string url) =>
        string.Concat(jsonUrl, url);
    
    /// <summary>
    /// Обрабатывает успешный ответ от сервера
    /// </summary>
    /// <param name="responseMessage">ответ от сервера полученный от метода HttpGetConnection или HttpPostConnection</param>
    /// <returns>возвращает общую модель ответа ResponseModel<T></returns>
    private async Task<ResponseModel<T>> HandleSuccessResponse(HttpResponseMessage responseMessage)
    {
        var jsonString = await responseMessage.Content.ReadAsStringAsync();
        var responseDto = JsonConvert.DeserializeObject<ResponseModel<T>>(jsonString);
                    
        return responseDto!;
    }

    /// <summary>
    /// Обрабатывает соединение с удаленным сервером c методом Get
    /// </summary>
    /// <param name="route">принимает собранный Url</param>
    /// <returns>возвращает общую модель ответа ResponseModel<T></returns>
    public async Task<ResponseModel<T>> GetConnectionHandler(string route)
    {
        try
        {
            var httpConnection = 
                await HttpGetConnection(route);

            if (httpConnection.IsSuccessStatusCode)
                return await HandleSuccessResponse(httpConnection);

            return await HandleFailResponse(httpConnection);
        }
        catch (Exception e)
        {
            return HandleException(e.Message);
        }
    }
    
    /// <summary>
    /// Обрабатывает соединение с удаленным сервером c методом Post
    /// </summary>
    /// <param name="route">принимает собранный Url</param>
    /// <param name="content">принимает сериализованный объект,
    /// принимаемый удаленным сервером для дальнейшей обработки.
    /// Например любая Dto сериализованная в Json методом "JsonConvert.SerializeObject(Dto)"</param>
    /// <returns>возвращает общую модель ответа ResponseModel<T></returns>
    public async Task<ResponseModel<T>> PostConnectionHandler(string route, string content)
    {
        try
        {
            var httpConnection = 
                await HttpPostConnection(route, content);

            if (httpConnection.IsSuccessStatusCode)
                return await HandleSuccessResponse(httpConnection);

            return await HandleFailResponse(httpConnection);
        }
        catch (Exception e)
        {
            return HandleException(e.Message);
        }
    }
    
    /// <summary>
    /// Создает подключение к удаленному серверу методом Get
    /// </summary>
    /// <param name="connectionString">Принимает url включая queryParam если они есть</param>
    /// <returns>возвращает ответ от сервера</returns>
    private async Task<HttpResponseMessage> HttpGetConnection(string connectionString)
    {
        using var client = new HttpClient();
        var connection = 
            await client.GetAsync(connectionString);
        return connection;
    }
    
    /// <summary>
    /// Создает подключение к удаленному серверу методом Post
    /// </summary>
    /// <param name="connectionString">собранный Url</param>
    /// <param name="content">сериализованный в Json объект, принимаемый на удаленном сервере</param>
    /// <returns>возвращает ответ от сервера</returns>
    private async Task<HttpResponseMessage> HttpPostConnection(string connectionString, string content)
    {
        using var client = new HttpClient();
        var contentRequest = new StringContent(content, Encoding.UTF8, "application/json");
        var connection = 
            await client.PostAsync(connectionString, contentRequest);
        return connection;
    }

    /// <summary>
    /// Обрабатывает не успешный ответ от сервера
    /// </summary>
    /// <param name="responseMessage">принимает ответ от сервера</param>
    /// <returns>возвращает общую модель ответа ResponseModel<T> с ошибками в себе, если они есть</returns>
    private async Task<ResponseModel<T>> HandleFailResponse(HttpResponseMessage responseMessage)
    {
        var responseDto = ResponseModel<T>.CreateFailed(new List<ResponseError?>
        {
            new ()
            {
                Code = "server"
            }
        });
                    
        return responseDto;
    }

    /// <summary>
    /// Обрабатывает ошибки, возникшие при попытке установить соединение с удаленным сервером
    /// </summary>
    /// <param name="e">принимает сообщение об ошибке</param>
    /// <returns>возвращает общую модель ответа ResponseModel<T> с ошибками Exeption e</returns>
    private ResponseModel<T> HandleException(string e) => 
        ResponseModel<T>.CreateFailed(new List<ResponseError?>
        {
            new()
            {
                Code = "server",
                Message = e
            }
        });
}