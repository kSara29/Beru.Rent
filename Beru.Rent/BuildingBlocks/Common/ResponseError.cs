namespace Common;

public class ResponseError
{
    public ResponseError(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public string Code { get; set; }
    public string Message { get; set; }
}