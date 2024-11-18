using MediatR;

public class UpdateCategoryCommandHandler(ICategoryRepository repository) : IRequestHandler<UpdateCategoryInfo, Result<bool>>
{
    public async Task<Result<bool>> Handle(UpdateCategoryInfo request, CancellationToken cancellationToken)
    {
        Category? category = await repository.GetByIdAsync(request.Id);
        if (category is null)
            return Result<bool>.Fail(Error.NotFound());

        if (category.IsDeleted)
            return Result<bool>.Fail(Error.NotFound());

        category.ToUpdate(request);
        int res = await repository.UpdateAsync(category);
        return res > 0
        ? Result<bool>.Success(true)
        : Result<bool>.Fail(Error.BadRequest());
    }
}