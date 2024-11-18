using MediatR;

public class CommentCreateCommandHandler(ICommentRepository repository) : IRequestHandler<CreateCommentInfo, Result<bool>>
{
    public async Task<Result<bool>> Handle(CreateCommentInfo request, CancellationToken cancellationToken)
    {
        int res = await repository.CreateAsync(request.ToCreate());
        return res > 0
        ? Result<bool>.Success(true)
        : Result<bool>.Fail(Error.BadRequest());
    }
}