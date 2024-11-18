using MediatR;

public readonly record struct CreateUserInfo(
    BaseUserInfo BaseUserInfo
) : IRequest<Result<bool>>;

public readonly record struct UpdateUserInfo(
    int Id,
    BaseUserInfo BaseUserInfo
) : IRequest<Result<bool>>;

public readonly record struct ReadUserInfo(
    int Id,
    BaseUserInfo BaseUserInfo,
    DateTime CreatedAt
) : IRequest<Result<bool>>;

public readonly record struct DeleteUserInfo(int Id) : IRequest<Result<bool>>;