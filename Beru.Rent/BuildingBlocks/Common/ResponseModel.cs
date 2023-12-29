namespace Common;

[Serializable]
public class ResponseModel<T>
{
    public required ResponseStatus Status { get; set; }
    public T? Data { get; init; }
    public ResponseError? Error { get; init; }

    public ResponseModel(T data)
    {
        Data = data;
    }

    public ResponseModel(ResponseError error)
    {
        Error = error;
    }

    public static ResponseModel<T> CreateSuccess(T data)
    {
        return new ResponseModel<T>(data)
        {
            Status = ResponseStatus.Success
        };
    }

    public static ResponseModel<T> CreateFailed(ResponseError error)
    {
        return new ResponseModel<T>(error)
        {
            Status = ResponseStatus.Failed
        };
    }
}