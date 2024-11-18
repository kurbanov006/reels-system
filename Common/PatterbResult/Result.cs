public record Result<T>
{
    public T? Value { get; set; }
    public Error? Error { get; set; }
    public bool IsSuccess { get; set; }
    private Result(T? value, Error error, bool isSuccess)
    {
        Value = value;
        Error = error;
        IsSuccess = isSuccess;
    }

    public static Result<T> Success(T value)
    => new Result<T>(value, Error.None(), true);

    public static Result<T> Fail(Error error)
    => new Result<T>(default, error, false);
}