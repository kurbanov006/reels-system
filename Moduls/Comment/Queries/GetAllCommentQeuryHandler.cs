using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetAllCommentHandler(ICommentRepository repository)
: IRequestHandler<CommentFilter, Result<PaginationResponse<IQueryable<ReadCommentInfo>>>>
{
    public async Task<Result<PaginationResponse<IQueryable<ReadCommentInfo>>>> Handle(CommentFilter request, CancellationToken cancellationToken)
    {
        IQueryable<Comment> comments = await repository.GetAllAsync();

        if (comments is null)
            return Result<PaginationResponse<IQueryable<ReadCommentInfo>>>.Fail(Error.NotFound());

        IQueryable<ReadCommentInfo> readComments = comments
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .Where(x => !x.IsDeleted)
            .Select(x => x.ToRead());

        int count = await readComments.CountAsync();

        PaginationResponse<IQueryable<ReadCommentInfo>> response =
        PaginationResponse<IQueryable<ReadCommentInfo>>.Create(request.PageNumber, request.PageSize, count, readComments);

        return Result<PaginationResponse<IQueryable<ReadCommentInfo>>>.Success(response);
    }
}