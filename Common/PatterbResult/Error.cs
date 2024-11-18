public sealed record Error
{
    public int? Code { get; init; }
    public string? Message { get; init; }
    public ErrorType ErrorType { get; set; }
    private Error()
    {
        Code = 500;
        Message = "Internal server error...!";
        ErrorType = ErrorType.InternalServerError;
    }

    private Error(int? code, string? message, ErrorType errorType)
    {
        Code = code;
        Message = message;
        ErrorType = errorType;
    }

    public static Error None()
        => new Error(null, null, ErrorType.None);
        
    public static Error NotFound(string? message = "Data not found!")
       => new(404, message, ErrorType.NotFound);

    public static Error BadRequest(string? message = "Bad request!")
        => new(400, message, ErrorType.BadRequest);

    public static Error Conflict(string? message = "Conflict!")
        => new(409, message, ErrorType.Conflict);

    public static Error InternalServerError(string? message = "Internal server error!")
        => new(500, message, ErrorType.InternalServerError);
}