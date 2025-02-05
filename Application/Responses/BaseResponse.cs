namespace Application.Responses;

public class BaseResponse
{
    public bool Succeeded { get; set; }
    public string Message { get; set; } = string.Empty;
    public List<string>? ValidationErrors { get; set; }

    public BaseResponse()
    {
        Succeeded = true;
    }

    public BaseResponse(string message)
    {
        Succeeded = true;
        Message = message;
    }

    public BaseResponse(bool success, string message)
    {
        Succeeded = success;
        Message = message;
    }
}
