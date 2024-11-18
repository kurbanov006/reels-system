using MediatR;

public record CategoryFilter : BaseFilter, IRequest<Result<PaginationResponse<IQueryable<ReadCategoryInfo>>>>
{

}