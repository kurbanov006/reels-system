using MediatR;

public class CommentDeleteCommandHandler(ICommentRepository repository) : IRequestHandler<DeleteComment, Result<bool>>
{
    public async Task<Result<bool>> Handle(DeleteComment request, CancellationToken cancellationToken)
    {
        Comment? comment = await repository.GetByIdAsync(request.Id);
        if (comment is null)
            return Result<bool>.Fail(Error.NotFound());

        comment.ToDelete();
        int res = await repository.UpdateAsync(comment);
        return res > 0
        ? Result<bool>.Success(true)
        : Result<bool>.Fail(Error.BadRequest());
    }
}


public record DeleteComment(int Id) : IRequest<Result<bool>>;