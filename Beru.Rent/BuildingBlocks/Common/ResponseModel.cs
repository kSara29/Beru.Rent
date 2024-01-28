namespace Common;

[Serializable]
public class ResponseModel<T>
{
    public required ResponseStatus Status { get; set; }
    public T? Data { get; init; }
    public List<ResponseError?> Errors { get; init; }

    public ResponseModel(T data)
    {
        Data = data;
    }

    public ResponseModel(List<ResponseError?> errors)
    {
        Errors = errors;
    }

    public static ResponseModel<T> CreateSuccess(T data)
    {
        return new ResponseModel<T>(data)
        {
            Status = ResponseStatus.Success
        };
    }

    public static ResponseModel<T> CreateFailed(List<ResponseError?> errors)
    {
        return new ResponseModel<T>(errors)
        {
            Status = ResponseStatus.Failed
        };
    }
}