using MediatR;

public record UserFilter : BaseFilter, IRequest<Result<PaginationResponse<IQueryable<ReadUserInfo>>>>
{

}