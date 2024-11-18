public record ApiResponse<T>
{
    public bool IsSuccess { get; set; }
    public List<string>? Messages { get; set; }
    public T? Value { get; set; }
    private ApiResponse(bool isSuccess, List<string>? messages, string message, T? value)
    {
        IsSuccess = isSuccess;
        if (message is not null)
            Messages?.Add(message);
        if (messages is not null)
            Messages = messages;
        Value = value;
    }

    public static ApiResponse<T> Success(List<string>? messages, T value, string message = "Success")
    => new ApiResponse<T>(true, messages, message, value);
    public static ApiResponse<T> Fail(List<string>? messages, T value, string message = "Fail")
    => new ApiResponse<T>(false, messages, message, value);
}