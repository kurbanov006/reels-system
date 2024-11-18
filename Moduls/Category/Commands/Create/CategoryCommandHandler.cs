using MediatR;

public class CategoryCommandHandler(ICategoryRepository repository) : IRequestHandler<CreateCategoryInfo, Result<bool>>
{
    public async Task<Result<bool>> Handle(CreateCategoryInfo request, CancellationToken cancellationToken)
    {
        IQueryable<Category> categories = await repository.GetAllAsync();

        bool conflict = categories.Any(x => x.Name == request.BaseCategoryInfo.Name);
        if (conflict)
            return Result<bool>.Fail(Error.Conflict());

        int res = await repository.CreateAsync(request.CreateCategory());
        return res > 0
        ? Result<bool>.Success(true)
        : Result<bool>.Fail(Error.BadRequest());
    }
}