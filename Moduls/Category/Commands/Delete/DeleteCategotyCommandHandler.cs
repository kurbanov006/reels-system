using MediatR;

public class DeleteCategoryCommandHandler(ICategoryRepository repository) : IRequestHandler<DeleteCategory, Result<bool>>
{
    public async Task<Result<bool>> Handle(DeleteCategory request, CancellationToken cancellationToken)
    {
        Category? category = await repository.GetByIdAsync(request.Id);
        if (category is null)
            return Result<bool>.Fail(Error.NotFound());

        category.ToDelete();
        int res = await repository.UpdateAsync(category);
        return res > 0
        ? Result<bool>.Success(true)
        : Result<bool>.Fail(Error.BadRequest());
    }
}

public readonly record struct DeleteCategory(int Id) : IRequest<Result<bool>>;