using MediatR;

public readonly record struct CreateCategoryInfo(
    BaseCategoryInfo BaseCategoryInfo
) : IRequest<Result<bool>>;

public readonly record struct UpdateCategoryInfo(
    int Id,
    BaseCategoryInfo BaseCategoryInfo
) : IRequest<Result<bool>>;

public readonly record struct ReadCategoryInfo(
    int Id,
    BaseCategoryInfo BaseCategoryInfo,
    DateTime CreatedAt
) : IRequest<Result<bool>>;