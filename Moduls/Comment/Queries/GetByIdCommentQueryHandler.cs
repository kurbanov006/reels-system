using MediatR;

public class GetByIdCommentQueryHandler(ICommentRepository repository) : IRequestHandler<GetByIdComment, Result<ReadCommentInfo>>
{
    public async Task<Result<ReadCommentInfo>> Handle(GetByIdComment request, CancellationToken cancellationToken)
    {
        Comment? comment = await repository.GetByIdAsync(request.Id);
        if (comment is null)
            return Result<ReadCommentInfo>.Fail(Error.NotFound());

        if (comment.IsDeleted)
            return Result<ReadCommentInfo>.Fail(Error.NotFound());

        return Result<ReadCommentInfo>.Success(comment.ToRead());

    }
}

public readonly record struct GetByIdComment(int Id) : IRequest<Result<ReadCommentInfo>>;