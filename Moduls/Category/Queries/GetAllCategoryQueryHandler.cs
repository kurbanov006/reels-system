using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetAllCategoryQueryHandler(ICategoryRepository repository)
: IRequestHandler<CategoryFilter, Result<PaginationResponse<IQueryable<ReadCategoryInfo>>>>
{
    public async Task<Result<PaginationResponse<IQueryable<ReadCategoryInfo>>>> Handle(CategoryFilter request, CancellationToken cancellationToken)
    {
        IQueryable<Category> categories = await repository.GetAllAsync();

        if (categories is null)
            return Result<PaginationResponse<IQueryable<ReadCategoryInfo>>>.Fail(Error.NotFound());

        IQueryable<ReadCategoryInfo> readCategories = categories
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .Where(x => !x.IsDeleted)
            .Select(x => x.ToRead());

        int count = await readCategories.CountAsync();

        PaginationResponse<IQueryable<ReadCategoryInfo>> response =
        PaginationResponse<IQueryable<ReadCategoryInfo>>.Create(request.PageNumber, request.PageSize, count, readCategories);

        return Result<PaginationResponse<IQueryable<ReadCategoryInfo>>>.Success(response);
    }
}