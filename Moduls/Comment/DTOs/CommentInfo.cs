using MediatR;

public readonly record struct CreateCommentInfo(
    BaseCommentInfo BaseCommentInfo
) : IRequest<Result<bool>>;

public readonly record struct UpdateCommentInfo(
    int Id,
    BaseCommentInfo BaseCommentInfo
) : IRequest<Result<bool>>;

public readonly record struct ReadCommentInfo(
    int Id,
    BaseCommentInfo BaseCommentInfo,
    DateTime CreatedAt
) : IRequest<Result<bool>>;