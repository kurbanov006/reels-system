using MediatR;

public record VideoFilter : BaseFilter, IRequest<Result<PaginationResponse<IQueryable<ReadVideoInfo>>>>
{

}