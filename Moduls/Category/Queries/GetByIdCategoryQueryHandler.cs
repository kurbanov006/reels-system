using MediatR;

public class GetByIdCategoryQueryHandler(ICategoryRepository repository) : IRequestHandler<GetByIdCategory, Result<ReadCategoryInfo>>
{
    public async Task<Result<ReadCategoryInfo>> Handle(GetByIdCategory request, CancellationToken cancellationToken)
    {
        Category? category = await repository.GetByIdAsync(request.Id);
        if (category is null)
            return Result<ReadCategoryInfo>.Fail(Error.NotFound());

        if (category.IsDeleted)
            return Result<ReadCategoryInfo>.Fail(Error.NotFound());

        return Result<ReadCategoryInfo>.Success(category.ToRead());
    }
}




public readonly record struct GetByIdCategory(int Id) : IRequest<Result<ReadCategoryInfo>>;