using MediatR;

public record CommentFilter : 
BaseFilter, IRequest<Result<PaginationResponse<IQueryable<ReadCommentInfo>>>>
{

}